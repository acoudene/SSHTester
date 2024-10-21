using Renci.SshNet;

Parallel.For(0, 100, async i =>
{
  using (var client = new SshClient("localhost", 2222, "anthony", "P@ssw0rd"))
  {
    client.Connect();
    // Make the server echo back the input file with "cat"
    using (SshCommand command = client.CreateCommand("cat"))
    {
      Task executeTask = command.ExecuteAsync(CancellationToken.None);

      using (Stream inputStream = command.CreateInputStream())
      {
        inputStream.Write("Hello World!"u8);
      }

      await executeTask;

      Console.WriteLine(command.ExitStatus); // 0
      Console.WriteLine(command.Result); // "Hello World!"
    }
  }
});