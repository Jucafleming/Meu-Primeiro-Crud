using Dapper;
using Grenciamento.Entidades;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Infra.Repositorio
{
    public class UsuarioRepositorio
    {
        //Metodos de conexão do banco
        private string connectionString;
        public UsuarioRepositorio()
        {
            connectionString = @"Integrated Security = SSPI; Persist Security Info = False; Initial Catalog = TESTE; Data Source = localhost; user = sa; password = ABC123@ç";
        }
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString); 
            }
        }


        //metodos CRUD

        public IEnumerable<Usuario> GetAll() //retorna "lista" de usuarios 
        {
            using (IDbConnection dbConnecton = Connection)
            {
                string sQuerry = @"select * from tbl_usuario";
                dbConnecton.Open();
                return dbConnecton.Query<Usuario>(sQuerry);
            }
        }

        public Usuario GetById(int id)
        {
            using (IDbConnection dbConnecton = Connection)
            {
                string sQuerry = @"select * from tbl_usuario where CPF = @CPF";
                dbConnecton.Open();
                return dbConnecton.Query<Usuario>(sQuerry, new { CPF = id }).FirstOrDefault();
            }
        }

        public void Add(Usuario usuario)
        {
            using (IDbConnection dbConnecton = Connection)
            {
                string sQuerry = @"insert into tbl_usuario (CPF,Nome,Sobrenome,Idade,Email) values (@CPF,@Nome,@Sobrenome,@Idade,@Email)";
                dbConnecton.Open();
                dbConnecton.Execute(sQuerry, usuario);
            }
        }

        public void Update(Usuario usuario)
        {
            using (IDbConnection dbConnecton = Connection)
            {
                string sQuerry = @"update tbl_usuario set Nome=@Nome,Sobrenome = @Sobrenome,Idade =@Idade, Email=@Email  where CPF = @CPF";
                dbConnecton.Open();
                dbConnecton.Query(sQuerry, usuario);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection dbConnecton = Connection)
            {
                string sQuerry = @"delete from tbl_usuario where CPF = @CPF";
                dbConnecton.Open();
                dbConnecton.Execute(sQuerry, new { CPF = id });
            }
        }

       
    }
}

