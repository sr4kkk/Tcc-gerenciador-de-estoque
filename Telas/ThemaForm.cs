using alguamcoisa.Utils;
using System;
using System.Windows.Forms;

namespace alguamcoisa
{
    public partial class ThemaForm : Form
    {
        private bool _carregando = false;

        public ThemaForm()
        {
            InitializeComponent();
        }

        private void ThemaForm_Load(object sender, EventArgs e)
        {
            _carregando = true;

            // Modo claro/escuro
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Claro");
            comboBox1.Items.Add("Escuro");
            comboBox1.SelectedIndex = AppTheme.Dark ? 1 : 0;

            // Paleta de cores (AccentScheme enum)
            comboBox2.Items.Clear();
            comboBox2.Items.Add(AppTheme.AccentScheme.Roxo);
            comboBox2.Items.Add(AppTheme.AccentScheme.Azul);
            comboBox2.Items.Add(AppTheme.AccentScheme.Verde);
            comboBox2.Items.Add(AppTheme.AccentScheme.Cinza);
            comboBox2.SelectedItem = AppTheme.CurrentAccentScheme;

            _carregando = false;

            // Aplica tema na própria tela de tema
            AppTheme.Apply(this);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_carregando) return;

            // 0 = Claro, 1 = Escuro
            bool dark = comboBox1.SelectedIndex == 1;
            AppTheme.SetDark(dark);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_carregando) return;

            if (comboBox2.SelectedItem is AppTheme.AccentScheme scheme)
            {
                AppTheme.SetAccentScheme(scheme);
            }
        }
    }
}
