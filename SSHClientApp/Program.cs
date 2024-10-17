using Renci.SshNet;

using (var client = new SshClient("localhost", 2222, "anthony", "P@ssw0rd"))
{
  client.Connect();
  using ShellStream shellStream = client.CreateShellStream("ShellName", 80, 24, 800, 600, 1024);
  client.Disconnect();
}