public static bool VerifyPassword(string u, string pwd2)
        {
            if (String.IsNullOrWhiteSpace(u) || String.IsNullOrWhiteSpace(pwd2))
                return false;

            string dbUser;
            string dbPass = null; //unncessary value allocation - string type is nullable and null by default


            //Instead of opening and closing SQL Connections manually - would maybe be worth alterinig the design of the system to use Entity Framework/ Identity Services to access the database/data models & validate user identity information.

            using (var conn = new SqlConnection("DefaultConnection")) //If using the Default connection string value from config file - should retrieve it using an IConfiguration service or Configuration constant. Simply writing "DefaultConnection" as a string will not provide the method with a valid connection string
            using (var command = new SqlCommand("SELECT * FROM Users WHERE uName = '" + u + "'", conn))//This query is open to a SQL Injection attack. The username string from the parameter is unsanitised meaning someone coud possibly pass any value they want into the SQL Query. Could be fixed by sanitising the input and failing the request if any unexpected/blacklisted symbols are present  
            {
                conn.Open();
                command.CommandType = CommandType.Text;
                SqlDataReader rdr = command.ExecuteReader();
                while (rdr.Read()) //No closing of SQLDataReader after the reading of the connection is complete - consider closing manually or incorporating it into a 'using' statement.
                {
                    dbUser = rdr["uName"].ToString();
                    dbPass = rdr["uPass"].ToString(); //Storing the password as plaintext in the database. (Of course - it could be that both the parameter string and database password values are hashes - but worth mentioning in case.)
                }
                //i.e. rdr.Close();
            }
            for (int j = 0; j < dbPass.Length; j++) //Could use the "Equals" method instead. dbPass.Equals(pwd2) etc.
            {
                if (dbPass[j] == pwd2[j])
                    continue;
                return false;
            }
            return true;
        }