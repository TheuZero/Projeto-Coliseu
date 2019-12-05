using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;

class DBConnect
{
    private MySqlConnection connection;
    private string server;
    private string database;
    private string uid;
    private string password;

    //Constructor
    public DBConnect()
    {
        Initialize();
    }

    //Initialize values
    private void Initialize()
    {
        server = "localhost";
        database = "FightersOfColosseum";
        uid = "root";
        password = "";
        string connectionString;
        connectionString = "SERVER=" + server + ";" + "DATABASE=" + 
		database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

        connection = new MySqlConnection(connectionString);
    }

    //open connection to database
    private bool OpenConnection()
    {
        try
        {
            connection.Open();
            return true;
        }
        catch (MySqlException ex)
        {
            return false;
        }
    }

//Close connection
    private bool CloseConnection()
    {
        try
        {
            connection.Close();
            return true;
        }
        catch (MySqlException ex)
        {
            return false;
        }
    }


    public void InsertScore(int score, int charId, int userId)
    {
        string query = $"INSERT INTO tb_pontuacoes (pontuacao, fk_id_personagem, fk_id_usuario,) VALUES('{score}', '{charId}', '{userId}')";

        
        if (this.OpenConnection() == true)
        {
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            this.CloseConnection();
        }
    }

    public void RegisterUser(string user, string password)
    {
        string query = $"INSERT INTO tb_usuario (usuario, senha) VALUES('{user}', '{password}')";

        
        if (this.OpenConnection() == true)
        {
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.ExecuteNonQuery();
            this.CloseConnection();
        }
    }

    public void UpdateSenha(int userId, string newPassword)
    {
        string query = $"UPDATE tb_usuario SET senha = '{newPassword}' WHERE id_usuario='{userId}'";

        if (this.OpenConnection() == true)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = query;
            cmd.Connection = connection;

            cmd.ExecuteNonQuery();
            this.CloseConnection();
        }
    }
/*
    public List<string>[] SelectUsuario()
    {
        string query = "SELECT * FROM tb_usuario";

        List<string>[] list = new List<string>[3];
        for(int i = 0; i < list.Length; i++){
            list[i] = new List<string>();
        }

        if (this.OpenConnection() == true)
        {
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            
            while (dataReader.Read())
            {
                list[0].Add(dataReader["id_usuario"] + "");
                list[1].Add(dataReader["usuario"] + "");
                list[2].Add(dataReader["senha"] + "");
            }

            dataReader.Close();

            this.CloseConnection();

            return list;
        }
        else
        {
            return list;
        }
    }
    */

    public List<string>[] SelectUsuario(int idUsuario)
    {
        string query = $"SELECT * FROM tb_usuario where id_usuario = '{idUsuario}'";

        List<string>[] list = new List<string>[3];
        for(int i = 0; i < list.Length; i++){
            list[i] = new List<string>();
        }

        if (this.OpenConnection() == true)
        {
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                list[0].Add(dataReader["id_usuario"] + "");
                list[1].Add(dataReader["usuario"] + "");
                list[2].Add(dataReader["senha"] + "");
            }
            dataReader.Close();
            this.CloseConnection();

            return list;
        }
        else
        {
            return list;
        }
    }

        public List<string>[] LoginUsuario(string user, string password)
    {
        string query = $"SELECT * FROM tb_usuario where usuario = {user} and senha = {password}";

        //Create a list to store the result
        List<string>[] list = new List<string>[3];
        for(int i = 0; i < list.Length; i++){
            list[i] = new List<string>();
        }

        //Open connection
        if (this.OpenConnection() == true)
        {
            //Create Command
            MySqlCommand cmd = new MySqlCommand(query, connection);
            //Create a data reader and Execute the command
            MySqlDataReader dataReader = cmd.ExecuteReader();
            
            //Read the data and store them in the list
            while (dataReader.Read())
            {
                list[0].Add(dataReader["id_usuario"] + "");
                list[1].Add(dataReader["usuario"] + "");
                list[2].Add(dataReader["senha"] + "");
            }

            //close Data Reader
            dataReader.Close();

            //close Connection
            this.CloseConnection();

            //return list to be displayed
            return list;
        }
        else
        {
            return list;
        }
    
    }
}
static class UserSession{
    public static int userId;
    public static string userName;
    public static bool IsLogged(){
        if(userId != 0 && userName != ""){
            return true;
        }
        return false;
    }
}