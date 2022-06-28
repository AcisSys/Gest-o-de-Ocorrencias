﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace Gestão_de_Ocorrencias
{
    public partial class adcModificar : Form
    {
        public adcModificar()
        {
            InitializeComponent();
        }

        public string ConnetionString { get; set; }

        public Int32 codigoreg;

        private void adcModificar_Load(object sender, EventArgs e)
        {
            string connetionString = null;
            SqlConnection cnn;
            connetionString = @"Data Source=ASUS-PORTATIL\SQLEXPRESS;Initial Catalog=testes;User ID=testes;Password=testes";
            cnn = new SqlConnection(connetionString);
            int rowsaffected = 0;

            try
            {
                cnn.Open();// Abre a conexão
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection: ! " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SqlCommand CmdCab = new SqlCommand("UPDATE Gestao SET  dtmData = @dtmData, hHora = @hHora, txtTitulo = @txtTitulo, " +
            "txtDescricao = @txtDescricao, cboGravidade = @cboGravidade, cboOperador = @cboOperador, txtTurno = @txtTurno, where ID = " + codigoreg, cnn);

            CmdCab.Parameters.AddWithValue("@dtmData", SqlDbType.Date).Value = dtmData.Value;
            CmdCab.Parameters.AddWithValue("@hHora", SqlDbType.DateTime2).Value = hHora.Value;
            CmdCab.Parameters.AddWithValue("@txtTitulo", SqlDbType.Text).Value = txtTitulo.Text;
            CmdCab.Parameters.AddWithValue("@txtDescricao", SqlDbType.Text).Value = txtDescricao.Text;
            CmdCab.Parameters.AddWithValue("@cboGravidade", SqlDbType.Text).Value = cboGravidade.Text;
            CmdCab.Parameters.AddWithValue("@cboOperador", SqlDbType.Text).Value = cboOperador.Text;
            CmdCab.Parameters.AddWithValue("@txtTurno", SqlDbType.Text).Value = txtTurno.Text;
            CmdCab.Parameters.AddWithValue("@ID", SqlDbType.Int).Value = Id;

            try
            {
                rowsaffected = CmdCab.ExecuteNonQuery(); // Executando o comando
            }
            catch (Exception ex)
            {
                MessageBox.Show("Inserir DocCab: " + ex.ToString());
                return; // Retorna o valor
            }

            cnn.Close(); // Fecha a conexão
            MessageBox.Show("Ocorrência modificada com sucesso!", "Ocorrencias", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Carrega();
            Update();
        }

        void Carrega()
        {
            string connetionString;
            SqlConnection cnn;
            connetionString = @"Data Source=ASUS-PORTATIL\SQLEXPRESS;Initial Catalog=testes;User ID=testes;Password=testes";
            cnn = new SqlConnection(connetionString);

            try
            {
                cnn.Open(); // Abre a conexão
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection: ! " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Retorna o valor
            }

            MessageBox.Show("Ocorrência modificada com sucesso!", "Ocorrencias", MessageBoxButtons.OK, MessageBoxIcon.Information);
            cnn.Close(); // Fecha a mensagem
        }

        string querry = @"INSERT INTO Gestao (dtmData, hHora, txtTitulo, txtDescricao, cboGravidade, cboOperador, txtTurno, ID) Values (@dtmData, @hHora, @txtTitulo, @txtDescricao, @cboGravidade, @cboOperador, @txtTurno, @ID)";

        public int Id { get; }
        private void btnGravar_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConnetionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand(querry, connection))
                {
                    sqlCommand.Parameters.AddWithValue("@dtmData", SqlDbType.Date).Value = dtmData.Value;
                    sqlCommand.Parameters.AddWithValue("@hHora", SqlDbType.DateTime2).Value = hHora.Value;
                    sqlCommand.Parameters.AddWithValue("@txtTitulo", SqlDbType.Text).Value = txtTitulo;
                    sqlCommand.Parameters.AddWithValue("@txtDescricao", SqlDbType.Text).Value = txtDescricao.Text;
                    sqlCommand.Parameters.AddWithValue("@cboGravidade", SqlDbType.Text).Value = cboGravidade.Text;
                    sqlCommand.Parameters.AddWithValue("@cboOperador", SqlDbType.Text).Value = cboOperador.Text;
                    sqlCommand.Parameters.AddWithValue("@txtTurno", SqlDbType.Text).Value = txtTurno.Text;
                    sqlCommand.Parameters.AddWithValue("@ID", SqlDbType.Int).Value = Id;
                    sqlCommand.ExecuteNonQuery();   
                }
            }

            // Inicia a conexão connetionString a base de dados
            string connetionString = null;
            SqlConnection cnn;
            connetionString = @"Data Source=ASUS-PORTATIL\SQLEXPRESS;Initial Catalog=testes;User ID=testes;Password=testes";
            cnn = new SqlConnection(connetionString);
            int rowsaffected = 0;
            try
            {
                cnn.Open();// Abre a conexão
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection: ! " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SqlCommand CmdCab = new SqlCommand("UPDATE Gestao SET  dtmData = @dtmData, hHora = @hHora, txtTitulo = @txtTitulo, " +
            "txtDescricao = @txtDescricao, cboGravidade = @cboGravidade, cboOperador = @cboOperador, txtTurno = @txtTurno, where ID =" + codigoreg, cnn);

            try
            {
                rowsaffected = CmdCab.ExecuteNonQuery(); // Executando o comando
            }

            catch (Exception ex)
            {
                MessageBox.Show("Inserir DocCab: " + ex.ToString());
                return; // Retorna o valor
            }
            cnn.Close(); // Fecha a conexão

            MessageBox.Show("Ocorrência modificada com sucesso!", "Ocorrencias", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
