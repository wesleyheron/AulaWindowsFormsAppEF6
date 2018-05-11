using AulaForms.Modelos;
using AulaForms.Repositorios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AulaForms
{
    public partial class Form1 : Form
    {
        int linhaSelecionada;
        public Form1()
        {
            InitializeComponent();
        }        

        private void Salvar(object sender, EventArgs e)
        {
            using (var ctx = new AlunoRepositorio())
            {
                Aluno aluno = new Aluno()
                {
                    Nome = nome.Text,
                    Cpf = cpf.Text,
                    DataNascimento = nascimento.Value,
                    Email = email.Text,
                    Sexo = sexo.Text
                };
                ctx.Adicionar(aluno);
                ctx.Salvar();
                MessageBox.Show("Aluno cadastrado com sucesso");
                ListaDados();
            }
        }

        private void Excluir(object sender, EventArgs e)
        {
            using (var ctx = new AlunoRepositorio())
            {
                int alunoId = int.Parse(id.Text);
                ctx.Excluir(alunoId);
                ctx.Salvar();
            }
            MessageBox.Show("Dados excluidos do sistema");
            ListaDados();
            
        }

        private void Atualizar(object sender, EventArgs e)
        {
            using (var ctx = new AlunoRepositorio())
            {
                var aluno = new Aluno()
                {
                    Id = int.Parse(id.Text),
                    Nome = nome.Text,
                    Cpf = cpf.Text,
                    Email = email.Text,
                    DataNascimento = nascimento.Value.Date,
                    Sexo = sexo.Text
                };
                ctx.Atualizar(aluno);
                ctx.Salvar();
                MessageBox.Show("Dados atualizados com sucesso");
                ListaDados();
            }
        }

        private void ListaDados()
        {
            try
            {
                using (var ctx = new AlunoRepositorio())
                {
                    lista.DataSource = ctx.ListarTodos();
                }
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
        }

        private void ListaSexo()
        {
            string[] sexos = { "Masculino", "Feminino" };
            sexo.DataSource = sexos;
        }

        private void SelecionarDados(object sender, DataGridViewCellEventArgs e)
        {
            linhaSelecionada = e.RowIndex;
            if (linhaSelecionada >= 0)
            {
                DataGridViewRow linha = lista.Rows[e.RowIndex];

                id.Text = linha.Cells[0].Value.ToString();
                nome.Text = linha.Cells[1].Value.ToString();
                nascimento.Text = linha.Cells[2].Value.ToString();
                cpf.Text = linha.Cells[3].Value.ToString();
                email.Text = linha.Cells[4].Value.ToString();
                sexo.Text = linha.Cells[5].Value.ToString();
           
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ListaSexo();
            ListaDados();
        }
    }
}
