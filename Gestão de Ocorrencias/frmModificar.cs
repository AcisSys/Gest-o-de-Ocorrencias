using System;
using System.Collections.Generic;
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

        public Int32 codigoreg;
        public string connectionString {get;set;}
        private void adcModificar_Load(object sender, EventArgs e)
        {
            string connetionString = null;
            SqlConnection cnn;
            
            cnn = new SqlConnection(connetionString);
            int rowsaffected = 0;

            try
            {
                cnn.Open();// Abre a conexão
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection: ! " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close(); // Retorna o valor
            }

            SqlCommand CmdCab = new SqlCommand("UPDATE Gestao SET  dtmData = @dtmData, hHora = @hHora, txtTitulo = @txtTitulo, " +
            "txtDescricao = @txtDescricao, cboGravidade = @cboGravidade, cboOperador = @cboOperador, txtTurno = @txtTurno, " +
            " where ID = " + codigoreg, cnn);


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
            this.Close(); // Fecha a mensagem


            Carrega();
        }

        void Carrega()
        {
            string connetionString = null;
            SqlConnection cnn;
         
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

        public int Id { get; }


        private void btnGravar_Click(object sender, EventArgs e)
        {
            // Inicia a conexão connetionString a base de dados
            string connetionString = null;
            SqlConnection cnn;
       
            cnn = new SqlConnection(connetionString);
            int rowsaffected = 0;
            try
            {
                cnn.Open();// Abre a conexão
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection: ! " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close(); // Retorna o valor
            }

            SqlCommand CmdCab = new SqlCommand("UPDATE Gestao SET  dtmData = @dtmData, hHora = @hHora, txtTitulo = @txtTitulo, " +
            "txtDescricao = @txtDescricao, cboGravidade = @cboGravidade, cboOperador = @cboOperador, txtTurno = @txtTurno, " +
            " where ID = " + codigoreg, cnn);

            // Adicionando parametros baseado no Sql
            CmdCab.Parameters.AddWithValue("@dtmData", SqlDbType.Date).Value = dtmData.Value;
            CmdCab.Parameters.AddWithValue("@hHora", SqlDbType.DateTime2).Value = hHora.Value;
            CmdCab.Parameters.AddWithValue("@txtTitulo", SqlDbType.Text).Value = txtTitulo;
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
            this.Close(); // Fecha a mensagem
        }
    }
}
