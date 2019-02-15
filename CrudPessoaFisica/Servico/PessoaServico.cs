using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CrudPessoaFisica.Servico
{
    public class PessoaServico
    {
        //Declarando Uma List ou "ArrayList"
        public List<CrudPessoaFisica.Entidade.Pessoa> ListaPessoa { get; set; }

        //Metodo Construtor
        public PessoaServico()
        {
            ListaPessoa = new List<CrudPessoaFisica.Entidade.Pessoa>();
        }

        //Metodo Consultar 
        public  CrudPessoaFisica.Entidade.Pessoa Consult (int cdg)
        {
           int posicao = LocalizaCodigo(cdg);
          CrudPessoaFisica.Entidade.Pessoa ps=null;

            if (posicao > 0)
            {
            
                ps = ListaPessoa[posicao - 1];
             }
          
            return ps;
         }

        //Metodo Salvar
        public bool salvarPessoa(CrudPessoaFisica.Entidade.Pessoa pessoa)
        {

            bool salvar = false;

            if (pessoa.Codigo == 0)
            {
                pessoa.Codigo = ListaPessoa.Count() + 1;
                ListaPessoa.Add(pessoa);
                
            }
            else
            {
                if (existeCodigo(pessoa.Codigo))
                {
                    var ps = ListaPessoa[pessoa.Codigo - 1];
                    ListaPessoa.Remove(ps);
                   ListaPessoa.Insert(pessoa.Codigo -   1, pessoa);
                }
            }

            return salvar;
        }

       //Metodo de Deletar
           public bool deletePessoa(int codigoPessoa)
        {
            bool deletar = false;
            int posicao = LocalizaCodigo(codigoPessoa);

            if (posicao>0)
            {
                CrudPessoaFisica.Entidade.Pessoa deletaPessoa = ListaPessoa[posicao - 1 ];
                ListaPessoa.Remove(deletaPessoa);
               
                deletar = true;
            }

            return deletar;
        }
        
        //Localiza Código
        public int LocalizaCodigo(int cdg)
       {
               int posicao = 1;
               int vr = 0;

               while (posicao <= ListaPessoa.Count)
               {
                   if (posicao == ListaPessoa.Count.CompareTo(0))
                   {
                       vr = posicao;
                   }

                   if (vr != cdg)
                   {
                       vr = posicao;
                   }

                   posicao++;
               }

               return vr;
           }


        //Metodo que Verifica se o Código Existe na lista
     public bool existeCodigo(int codigoPessoa)
        {
            bool existe = false;

            foreach (var item in ListaPessoa)
            {
                if (item.Codigo == codigoPessoa)
                {
                    existe = true;
                    break;
                }
            }   
            
            return existe;
            
        }
    }

}
