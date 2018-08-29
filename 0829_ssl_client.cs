           public void RunClient()
            {
                string machineName = "my-loaner.myworld.local";
                string serverName= "clientmachine";
                //get the client certificate from the store on the local machine               
               xCert = PickCertificate(StoreLocation.LocalMachine, StoreName.My);

               // Load the certificate into an X509Certificate object.
                var xCertColl = new X509CertificateCollection {xCert};

                // Create a TCP/IP client socket.
                // machineName is the host running the server application.
                TcpClient client = new TcpClient(machineName,443);

                //Console.WriteLine("Client connected.");
                // Create an SSL stream that will close the client's stream.
                SslStream sslStream = new SslStream(
                    client.GetStream(),
                    true,
                    new RemoteCertificateValidationCallback(ValidateServerCertificate),
                    null
                    );
                // The server name must match the name on the server certificate.
                try
                {
                    sslStream.AuthenticateAsClient(serverName, new X509CertificateCollection(xCertColl), SslProtocols.Tls, false);
                }
                catch (AuthenticationException e)
                {
                    Console.WriteLine("Exception: {0}", e.Message);
                    if (e.InnerException != null)
                    {
                        Console.WriteLine("Inner exception: {0}", e.InnerException.Message);
                    }
                    Console.WriteLine("Authentication failed - closing the connection.");
                    client.Close();
                    return;
                }
                
                byte[] messsage =Encoding.UTF8.GetBytes("GET /default.aspx?=23 HTTP/1.1\r\nHost: my-loaner.myworld.local\r\nAccept: */*\r\n\r\n");
                // Send hello message to the server. 
                sslStream.Write(messsage);
                sslStream.Flush();
                StreamResponse = sslStream;
                Image2.ImageUrl = WriteRequest();
                // Read message from the server.
               // string serverMessage = ReadMessage(sslStream);
                //Console.WriteLine("Server says: {0}", serverMessage);
                // Close the client connection.
                client.Close();
                Console.WriteLine("Client closed.");
            }
private static X509Certificate2 PickCertificate(
                         StoreLocation location, StoreName name)
        {
            var store = new X509Store(name, location);
            try
            {
                store.Open(OpenFlags.ReadOnly);
                X509Certificate2 cert;
                if(store.Certificates.Count == 1)
                    cert = store.Certificates[0];
                else
                {
                // pick a certificate from the store
                     cert =
                        X509Certificate2UI.SelectFromCollection(
                            store.Certificates, "Caption",
                            "Message", X509SelectionFlag.SingleSelection)[0];
                }
                // show certificate details dialog
               // X509Certificate2UI.DisplayCertificate(cert);
                return cert;
            }
            finally { store.Close(); }
        }