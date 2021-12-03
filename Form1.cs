using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Daniel_Taschenrechner
{
    public partial class Taschenrechner : Form
    {
        public Taschenrechner()
        {
            InitializeComponent();
        }



        private string num1 = "";

        private string num2 = "";

        private string op = "";

        private string erg = "";

        

        #region "ZeichenEinfügen"

        private void btnNr1_Click(object sender, EventArgs e)
        {
            ZeichenEinfügen('1');
        }

        private void btnNr2_Click(object sender, EventArgs e)
        {
            ZeichenEinfügen('2');
        }

        private void btnNr3_Click(object sender, EventArgs e)
        {
            ZeichenEinfügen('3');
        }

        private void btnNr4_Click(object sender, EventArgs e)
        {
            ZeichenEinfügen('4');
        }

        private void btnNr5_Click(object sender, EventArgs e)
        {
            ZeichenEinfügen('5');
        }

        private void btnNr6_Click(object sender, EventArgs e)
        {
            ZeichenEinfügen('6');
        }

        private void btnNr7_Click(object sender, EventArgs e)
        {
            ZeichenEinfügen('7');
        }

        private void btnNr8_Click(object sender, EventArgs e)
        {
            ZeichenEinfügen('8');
        }

        private void btnNr9_Click(object sender, EventArgs e)
        {
            ZeichenEinfügen('9');
        }

        private void btnNr0_Click(object sender, EventArgs e)
        {
            ZeichenEinfügen('0');

        }

        private void ZeichenEinfügen(char chr)
        {
            txtEingabe.Text += chr;

           

            Ausgabe();
        }

        #endregion


        private void btnKomma_Click(object sender, EventArgs e)
        {
            if (!ZeichenExistiert(txtEingabe.Text, ','))
            {
                txtEingabe.Text += ",";
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear2();
        }

        private void btnWurzel_Click(object sender, EventArgs e)
        {
            try
            { 
            if (IsDecimal(txtEingabe.Text))
            {
                num1 = txtEingabe.Text;
                txtEingabe.Text = "";
            }

            if (num1 != "")
            {
                op = btnWurzel.Text;                
                double val1 = Double.Parse(num1);
                if (val1 > 0)
                {
                    erg = Math.Sqrt(val1).ToDigits(); ;
                }
                else
                {
                    MessageBox.Show("Es kann keine negative Wurzel gezogen werden", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }

            Ausgabe();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHoch_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsDecimal(txtEingabe.Text))
            {
               num1 = txtEingabe.Text;
                txtEingabe.Text = "";
            }

            if(num1 != "")
            {
                op = btnHoch.Text;
                erg = (ConvertToDecimal(num1) * ConvertToDecimal(num1)).ToDigits(); ;
               
            }

            Ausgabe();
        }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
}
        private void btnRest_Click(object sender, EventArgs e)
        {
            OpSetzen(btnRest.Text);
        }


        private void btnGeteilt_Click(object sender, EventArgs e)
        {
            OpSetzen(btnGeteilt.Text);
        }

        private void btnMal_Click(object sender, EventArgs e)
        {
            OpSetzen(btnMal.Text);
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {

            OpSetzen(btnPlus.Text);
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            OpSetzen(btnMinus.Text);        
        }

        private void btnErgebnis_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsDecimal(txtEingabe.Text))
                {
                    num2 = txtEingabe.Text;
                    txtEingabe.Clear();
                }

                if (op != "" && num1 != "" && num2 != "")
                {
                    txtEingabe.Clear();
                    switch (op)
                    {
                        case "+":
                            erg = (ConvertToDecimal(num1) + ConvertToDecimal(num2)).ToDigits();
                            lblRechnung.Text = (num1 + " + " + num2 + " = " + erg);

                            break;
                        case "-":
                            erg = (ConvertToDecimal(num1) - ConvertToDecimal(num2)).ToDigits();
                            lblRechnung.Text = (num1 + " - " + num2 + " = " + erg);
                            break;
                        case "x":
                            erg = (ConvertToDecimal(num1) * ConvertToDecimal(num2)).ToDigits();
                            lblRechnung.Text = (num1 + " x " + num2 + " = " + erg);
                            break;
                        case "/":
                            erg = (ConvertToDecimal(num1) / ConvertToDecimal(num2)).ToDigits();
                            lblRechnung.Text = (num1 + " / " + num2 + " = " + erg);
                            break;
                        case "R":
                            if (ConvertToDecimal(num1) < ConvertToDecimal(num2))
                            {
                                MessageBox.Show("Die erste Zahl muss größer als die zweite Zahl sein ");
                            }
                            else
                            {
                                erg = (ConvertToDecimal(num1) % ConvertToDecimal(num2)).ToDigits();
                                lblRechnung.Text = ("Der Rest von " + num1 + " / " + num2 + " = " + erg);
                            }
                            break;
                        default:
                            break;
                    }
                   
                    txtEingabe.Text = "";
                    lstErgebnisse.Items.Add(num1 + " " + op + " " + num2 + " = " + erg);
                    num1 = erg;
                    op = "";
                    num2 = "";
                    erg = "";

                    Ausgabe();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLöschen_Click(object sender, EventArgs e)
        {
            if (txtEingabe.Text.Length != 0)
            {
                txtEingabe.Text = txtEingabe.Text.Remove(txtEingabe.Text.Length - 1);
            }
            else
            {
                MessageBox.Show("Es ist kein Wert vorhanden der gelöscht werden kann");
            }


        }

        private decimal ConvertToDecimal(string text)
        {
            decimal valueAsDec;

            bool result = Decimal.TryParse(text, out valueAsDec);
            if (result == false)
            {
                MessageBox.Show(txtEingabe.Text + " kann nicht in eine Zahl umgewandelt werden", "Fehler",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return 0;
            }
            else
            {
                return valueAsDec;
            }
        }

        private bool IsDecimal(string value)
        {
            decimal valueAsDec;
            bool result = Decimal.TryParse(value, out valueAsDec);
            if (result == false)
            {
              
                return false;


            } else
            {
                return true;
            }
        }

        private bool ZeichenExistiert(string text, char chr)
        {

            bool zeichenExitiert = false;
            foreach (char c in text.ToCharArray())
            {
                if (c == chr)
                {
                    zeichenExitiert = true;


                }
            }

            return zeichenExitiert;


        }

        private void Ausgabe()
        {

            if (erg != "")
            {
                if (op == "W")
                {
                    lblRechnung.Text = erg;
                    lstErgebnisse.Items.Add(num1 + " " + op + " " +  " = " + erg);
                    num1 = erg; num1 = erg;
                    op = "";              
                    erg = "";


                }
                else if (op == "H")
                {
                    lblRechnung.Text =  erg;
                    lstErgebnisse.Items.Add(num1 + "² " + " = " + erg);
                    num1 = erg;
                    op = "";
                    erg = "";
                }
                else
                {
                    lblRechnung.Text =  erg;
                }
            }
            else if (num2 != "")
                lblRechnung.Text = num1 + " " + op + " " + num2;
            else if (op != "")
                lblRechnung.Text = num1 + " " + op;
            else if (num1 != "")
                lblRechnung.Text = num1;
            else
                lblRechnung.Text = "";

        }

        private void btnAc_Click(object sender, EventArgs e)
        {
            lstErgebnisse.Items.Clear();
            txtEingabe.Clear();
            clear2();



        }

        private void clear2()
        {
            txtEingabe.Clear();
            erg = "";
            num1 = "";
            num2 = "";
            op = "";
            
            Ausgabe();
    
    }

        private void OpSetzen(string _op)
        {
            if(IsDecimal(txtEingabe.Text))
            {
                if (op == "" || num1 == "")
                {
                    num1 = txtEingabe.Text;
                    txtEingabe.Clear();
                }
                else if (num1 != "")
                {
                    btnErgebnis.PerformClick();
                }

            }
           
            op = _op;

            Ausgabe();
        }

        
    }

    public static class Extensions
    {
        public static string ToDigits(this decimal value)
        {
            return value.ToString("0.#######################################");
        }

        public static string ToDigits(this double value)
        {
            return value.ToString("0.#######################################");
        }
    }
}

          




        








    

