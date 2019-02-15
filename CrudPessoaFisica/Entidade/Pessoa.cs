using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrudPessoaFisica.Entidade
{
   public  class Pessoa
    {

       //Metodo Construtor
       public Pessoa() { }

       //Metodos de Acesso
       public int Codigo { get; set; }
       public String RazaoSocial { get; set; }
       public String NomeFantasia { get; set; }
       public String CNPJ { get; set; }
   }
}
