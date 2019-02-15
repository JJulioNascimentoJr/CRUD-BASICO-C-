using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace CrudPessoaFisica
{
    public partial class FmrPessoaFisica : Form
    {
        //metodos de acesso da classe PessoaServico
        CrudPessoaFisica.Servico.PessoaServico PessoaServico { get; set; }

        //Metodo Construtor
        public FmrPessoaFisica()
        {
            InitializeComponent();

            //Instanciando a Classe PessoaServico 
            PessoaServico = new Servico.PessoaServico();
        }

        //Metodo de Evento Salvar
        private void btnSalvar_Click(object sender, EventArgs e)
        {

            bool verifica = true;

            #region Valida dados
            if (txtRS.Text.Length < 0)
            {
                MessageBox.Show("Informe uma Razão Social...");
                verifica = false;
            }

            if (txtNF.Text.Length < 0)
            {
                MessageBox.Show("Informe um Nome Fantasia...");
                verifica = false;
            }

            if (txtCNPJ.Text.Length>18)
            {
                
                MessageBox.Show("Informe um CNPJ Valido...");
                verifica = false;
            }
            else
            {
                if (!Regex.IsMatch(txtCNPJ.Text, @"^\d{2}.?\d{3}.?\d{3}/?\d{4}-?\d{2}$"))
                {
                    MessageBox.Show(" O CNPJ  Informado é Invalido");
                    verifica = false;
                }
            }
            #endregion

            if (verifica == true)
            {
                CrudPessoaFisica.Entidade.Pessoa pessoa = new
                        CrudPessoaFisica.Entidade.Pessoa();

                pessoa.RazaoSocial = txtRS.Text;
                pessoa.NomeFantasia = txtNF.Text;
                pessoa.CNPJ = txtCNPJ.Text;

                PessoaServico.salvarPessoa(pessoa);
                carregarGrid();
                limpaTela();

                MessageBox.Show("Cadastro Salvo com Secesso...");
            }
        }
        
        //Metodo de Evento Consultar
        private void btnConsult_Click(object sender, EventArgs e)
        {

            bool verifica = true;

            #region Valida Codigo
            if (txtCodigo.Text.Length == 0)
            {
                MessageBox.Show("Informe um Código...");
                verifica = false;
            }


            int cdg;
            int.TryParse(txtCodigo.Text, out cdg);

            if (cdg < 0)
            {
                MessageBox.Show("Informe um Numero Inteiro...");
                verifica = false;
            }
            # endregion

            if (verifica == true)
            {
              
                CrudPessoaFisica.Entidade.Pessoa pessoa = PessoaServico.Consult(cdg);
                  
             if (pessoa==null)
              {
                   MessageBox.Show("Código Informado não Encontrado...");
              }
              else
              {
                    txtRS.Text = pessoa.RazaoSocial;
                    txtNF.Text = pessoa.NomeFantasia;
                    txtCNPJ.Text = pessoa.CNPJ;
               }
            }
        }
       
        //Metodo de Evendo Deletar
        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool verifica = true;

            #region Valida Codigo
            if (txtCodigo.Text.Length == 0)
            {
                MessageBox.Show("Informe um Código...");
                verifica = false;
            }

            int cdg;
            int.TryParse(txtCodigo.Text, out cdg);

            if (cdg < 0)
            {
                MessageBox.Show("Informe um Numero Inteiro...");
                verifica = false;
            }
            # endregion

            if (verifica == true)
            {
                bool deletar = PessoaServico.deletePessoa(cdg);

                if (!deletar)
                {
                    MessageBox.Show("Código Informado não existe...");
                }
                else
                {
                    MessageBox.Show("Os Dados foram excluidos com Sucesso...");
                    carregarGrid();
                    limpaTela();
                }
            }
        }

        //Carregar Informações na Tela
        private void carregarGrid()
        {
            dgView.DataSource = null;
            dgView.DataSource = PessoaServico.ListaPessoa;

        }

        //Limpar as Informações da Tela
        private void limpaTela()
        {
            txtCodigo.Text = null;
            txtRS.Text = null;
            txtNF.Text = null;
            txtCNPJ.Text = null;

        }
    }
}
