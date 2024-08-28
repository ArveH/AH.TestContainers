using System.Net;
using System.Net.Sockets;
using DotNet.Testcontainers.Containers;
using Testcontainers.PostgreSql;

namespace AH.TestLib;

// Found here: https://github.com/testcontainers/testcontainers-dotnet/issues/1148
public static class TestContainerExtensions {

    public static Task<bool> WaitForPort(this PostgreSqlContainer container, TimeSpan? maxWait = null) {
        return WaitForPort(container, PostgreSqlBuilder.PostgreSqlPort, maxWait ?? TimeSpan.FromSeconds(10));
    }

    // Found here: https://github.com/testcontainers/testcontainers-dotnet/issues/1148
    public static async Task<bool> WaitForPort(this DockerContainer container, int unmappedPort, TimeSpan maxWait) {
        var ips = await Dns.GetHostAddressesAsync(container.Hostname);
        if (ips.Length != 1) {
            throw new ArgumentException($"Expected 1 IP to resolve from '{container.Hostname}', but got {ips.Length} ({string.Join(", ", ips.Select(i => i.ToString()))})");
        }

        int portNumber = container.GetMappedPublicPort(unmappedPort);

        using CancellationTokenSource ts = new();
        ts.CancelAfter(maxWait);
        
        using var tcpClient = new TcpClient();

        while (!ts.IsCancellationRequested) {
            try
            {
                await tcpClient.ConnectAsync(ips[0], portNumber, ts.Token);
                return true;
            }
            catch (SocketException)
            {
                // Ignore
            }
            await Task.Delay(500, ts.Token); 
        }

        return false;
    }
}
