using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private List<Factory> _list = new List<Factory>();//контейнер для зберігання заводів

        public Form1()
        {
            InitializeComponent();
        }
        private void create_factory_Click(object sender, EventArgs e)
        {
            string FactoryName = textBox1.Text;
            int CountOfDepartment;
            int MasterSalary;
            int EmployeeSalary;
            int MonthBenefitFactoryFromEmployee;
            int MonthBenefitFactoryFromMaster;
            try
            {
                if (FactoryName == "")
                    throw new Exception();
                CountOfDepartment = Convert.ToInt32(textBox2.Text);
                MasterSalary = Convert.ToInt32(textBox3.Text);
                EmployeeSalary = Convert.ToInt32(textBox4.Text);
                MonthBenefitFactoryFromEmployee = Convert.ToInt32(textBox5.Text);
                MonthBenefitFactoryFromMaster = Convert.ToInt32(textBox6.Text);
                _list.Add(new Factory(FactoryName, CountOfDepartment, MasterSalary, EmployeeSalary, MonthBenefitFactoryFromEmployee, MonthBenefitFactoryFromMaster));
                comboBox1.Items.Add(FactoryName);
                comboBox2.Items.Add(FactoryName);
            }
            catch
            {
                MessageBox.Show("Невірно введені дані!");
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBox1.SelectedIndex;
            textBox1.Text = _list[index].FactoryName;
            textBox2.Text = _list[index].CountOfDepartment.ToString();
            textBox3.Text = _list[index].MasterSalary.ToString();
            textBox4.Text = _list[index].EmployeeSalary.ToString();
            textBox5.Text = _list[index].MonthBenefitFromEmployee.ToString();
            textBox6.Text = _list[index].MonthBenefitFromMaster.ToString();
            textBox7.Text = _list[index].CountOfEmployees.ToString();
            textBox8.Text = _list[index].CountOfMasters.ToString();

        }
        private void hire_employee_Click(object sender, EventArgs e) //найм робітників
        {
            if (comboBox1.SelectedIndex == -1)
                return;
            int index = comboBox1.SelectedIndex;
            _list[index].HireEmployee();
            textBox7.Text = _list[index].CountOfEmployees.ToString();
        }
        private void hire_master_Click(object sender, EventArgs e) //найм майстрів
        {
            if (comboBox1.SelectedIndex == -1)
                return;
            int index = comboBox1.SelectedIndex;
            _list[index].HireMaster();
            textBox8.Text = _list[index].CountOfMasters.ToString();
        }
        private void dismiss_employee_Click(object sender, EventArgs e) //звільнення робітників
        {
            if (comboBox1.SelectedIndex == -1)
                return;
            int index = comboBox1.SelectedIndex;
            _list[index].DismissEmployee();
            textBox7.Text = _list[index].CountOfEmployees.ToString();
            textBox8.Text = _list[index].CountOfMasters.ToString();
        }
        private void dismiss_master_Click(object sender, EventArgs e) //звільнення майстрів
        {
            if (comboBox1.SelectedIndex == -1)
                return;
            int index = comboBox1.SelectedIndex;
            _list[index].DismissMaster();
            textBox7.Text = _list[index].CountOfEmployees.ToString();
            textBox8.Text = _list[index].CountOfMasters.ToString();
        }
        private void factory_copy_Click(object sender, EventArgs e) //копіювання заводу
        {
            if (comboBox1.SelectedIndex == -1)
                return;
            int index = comboBox1.SelectedIndex;
            _list.Add(new Factory(_list[index]));
            comboBox1.Items.Add(_list[index].FactoryName);
            comboBox2.Items.Add(_list[index].FactoryName);
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                comboBox2.Enabled = true;
                factory_comparison.Enabled = true;
                link_factories.Enabled = true; 
            }
            if (!checkBox1.Checked)
            {
                comboBox2.Enabled = false;
                factory_comparison.Enabled = false;
                link_factories.Enabled = false;
            }
        }
        private void factory_comparison_Click(object sender, EventArgs e) //порівняння заводів
        {
            if(comboBox1.SelectedIndex != -1 && comboBox2.SelectedIndex != -1)
            {
                int index1 = comboBox1.SelectedIndex;
                int index2 = comboBox2.SelectedIndex;
                _list[index1].CompareTo(_list[index2]);
            }
        }
        private void link_factories_Click(object sender, EventArgs e) //об'єднання заводів
        {
            if (comboBox1.SelectedIndex != -1 && comboBox2.SelectedIndex != -1)
            {
                int index1 = comboBox1.SelectedIndex;
                int index2 = comboBox2.SelectedIndex;
                _list.Add(_list[index1] + _list[index2]);
                comboBox1.Items.Add(_list[_list.Count - 1].FactoryName);
                comboBox2.Items.Add(_list[_list.Count - 1].FactoryName);
            }
        }
        private void do_investment_Click(object sender, EventArgs e) //extansion mathod
        {
            if (comboBox1.SelectedIndex == -1)
                return;
            int index = comboBox1.SelectedIndex;
            double investment = 0;
            try
            {
                investment = Convert.ToDouble(textBox9.Text);
            }
            catch
            {
                MessageBox.Show("Невірно введено число!");
            }
            double value = _list[index].Do_Investment(investment);
            textBox10.Text = value.ToString();
        }

        private void Form1_Load(object sender, EventArgs e) //встановка курсора в textbox1
        {
            textBox1.Select();
            textBox1.ScrollToCaret();
        }
    }
}
