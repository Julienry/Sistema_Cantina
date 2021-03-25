using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Cantina
{
    public partial class Form1 : Form
    {
        // Declaração de 3 arrays para armazenar 10 produtos, e seus
        // respectivos códigos e valores.
        string[] produtos = new string[10];
        string[] codigo = new string[10];
        double[] valor = new double[10];
        double soma;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            // Inicia com uma condição, se o usuário digitas um código 
            // com 3 caracteres(length), esse código é adicionado ao listBox.
            if (txtCodigo.Text.Length == 3)
            {

                // Procura o produto e retorna as informações de acordo com o índice.
                int i = 0;
                for(int produto = 1; produto < codigo.Length; produto++)
                {
                    if(txtCodigo.Text == codigo[produto])
                    {
                        i = produto;
                    }
                }

                if (i == 0)
                {
                    MessageBox.Show("Produto não encontrado");
                }

                // Adiciona as informações ao ListBox (código/nome/valor). 
                else
                {
                    lstCaixa.Items.Add(txtCodigo.Text + " -- " + produtos[i] + "-- R$ "
                        + valor[i]);
                }
                soma = soma + valor[i];
                lblValor.Text = ("Valor total: R$ " + soma);
                
                // Seleciona a imagem do produto baseado no índice atual.
                switch (i)
                {
                    case 1:
                        picImagem.Image = Sistema_Cantina.Properties.Resources.Pastel;
                        break;
                    case 2:
                        picImagem.Image = Sistema_Cantina.Properties.Resources.Coxinha;
                        break;
                    case 3:
                        picImagem.Image = Sistema_Cantina.Properties.Resources.Hot_Dog;
                        break;
                    case 4:
                        picImagem.Image = Sistema_Cantina.Properties.Resources.Chocolate;
                        break;
                    case 5:
                        picImagem.Image = Sistema_Cantina.Properties.Resources.Suco;
                        break;
                }
                
                // O TextBox será limpo.
                txtCodigo.Text = "";
                // O Focus posiciona o curso do TextBox para uma nova digitação.
                txtCodigo.Focus();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Ao entrar no Form Load o método carregarArray será chamado.
            CarregarArray();
            soma = 0;
        }

        private void CarregarArray()
        {
            // Códigos, Produtos e Valores referenciam os arrays que foram declarados.

            codigo[1] = "001";
            codigo[2] = "002";
            codigo[3] = "003";
            codigo[4] = "004";
            codigo[5] = "005";

            produtos[1] = "Pastel";
            produtos[2] = "Coxinha";
            produtos[3] = "Hot Dog";
            produtos[4] = "Chocolate";
            produtos[5] = "Suco";

            valor[1] = 6.00;
            valor[2] = 5.00;
            valor[3] = 12.00;
            valor[4] = 3.50;
            valor[5] = 8.00;
        }

        private void btnCodigos_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Digite códigos de 001 a 005 para escolher os produtos.", 
                "Códigos");
        }

        private void btnResetar_Click(object sender, EventArgs e)
        {
            lblValor.Text = ("Valor total: R$0");
            lstCaixa.Items.Clear();
            picImagem.Image = null;
            soma = 0;
        }
    }
}
