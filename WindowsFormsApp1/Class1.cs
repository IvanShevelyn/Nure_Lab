using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class Factory : IComparable<Factory>
    {
        public string FactoryName { get => _FactoryName; }
        private string _FactoryName;
        public int CountOfDepartment { get => _CountOfDepartment; }
        private int _CountOfDepartment;
        public int CountOfMasters { get => _CountOfMasters; }
        private int _CountOfMasters;
        public int CountOfEmployees { get => _CountOfEmployees; }
        private int _CountOfEmployees;
        public int MasterSalary { get => _MasterSalary; }
        private int _MasterSalary;
        public int EmployeeSalary { get => _EmployeeSalary; }
        private int _EmployeeSalary;
        public int MonthBenefitFromMaster { get => _MonthBenefitFactoryFromMaster; }
        private int _MonthBenefitFactoryFromMaster;
        public int MonthBenefitFromEmployee { get => _MonthBenefitFactoryFromEmployee; }
        private int _MonthBenefitFactoryFromEmployee;

        public Factory()
        {

        }
        public Factory(string FactoryName, int CountOfDepartment, int MasterSalary, int EmployeeSalary, int MonthBenefitFactoryFromEmployee, int MonthBenefitFactoryFromMaster) // конструктор с параметрами
        {
            _FactoryName = FactoryName;
            _CountOfDepartment = CountOfDepartment;
            _CountOfMasters = 0;
            _CountOfEmployees = 0;
            _MasterSalary = MasterSalary;
            _EmployeeSalary = EmployeeSalary;
            _MonthBenefitFactoryFromEmployee = MonthBenefitFactoryFromEmployee;
            _MonthBenefitFactoryFromMaster = MonthBenefitFactoryFromMaster;
        }
        public Factory(Factory other) //конструктор копирования  
        {
            _FactoryName = other._FactoryName;
            _CountOfDepartment = other._CountOfDepartment;
            _CountOfMasters = other._CountOfMasters;
            _CountOfEmployees = other._CountOfEmployees;
            _MasterSalary = other._MasterSalary;
            _EmployeeSalary = other._EmployeeSalary;
            _MonthBenefitFactoryFromMaster = other._MonthBenefitFactoryFromMaster;
            _MonthBenefitFactoryFromEmployee = other._MonthBenefitFactoryFromEmployee;
        }
        public static Factory operator +(Factory A, Factory B) //оператор + 
        {
            var result = new Factory();

            result._FactoryName = A._FactoryName + " " + B._FactoryName;
            result._CountOfDepartment = A._CountOfDepartment + B._CountOfDepartment;
            result._CountOfEmployees = A._CountOfEmployees + B._CountOfEmployees;
            if (result._CountOfEmployees % 10 == 0)
                result._CountOfMasters = result._CountOfEmployees / 10;
            else
                result._CountOfMasters = result._CountOfEmployees / 10 + 1;
            result._MasterSalary = (A._MasterSalary + B._MasterSalary) / 2;
            result._EmployeeSalary = (A._EmployeeSalary + B._EmployeeSalary) / 2;
            result._MonthBenefitFactoryFromEmployee = (A._MonthBenefitFactoryFromEmployee + B._MonthBenefitFactoryFromEmployee) / 2;
            result._MonthBenefitFactoryFromMaster = (A._MonthBenefitFactoryFromMaster + B._MonthBenefitFactoryFromMaster) / 2;
            return result;
        }
        public void HireEmployee() //метод нанятия работника
        {
            if (_CountOfMasters == 0)
            {
                MessageBox.Show("Немає майстрів! Неможливо найняти робітника");
                return;
            }
            if (_CountOfEmployees / _CountOfMasters == 10 && _CountOfEmployees % 10 == 0)
            {
                MessageBox.Show("Забагато працівників, треба найняти майстра");
                return;
            }
            else
            {
                _CountOfEmployees++;
            }
        }
        public void HireMaster() //метод нанятия мастера
        {
            if (_CountOfMasters == 0)
            {
                _CountOfMasters++;
                MessageBox.Show("Майстра найнято, тепер наймайте працівників!");
                return;
            }
            if (_CountOfEmployees % 10 == 0 && _CountOfEmployees / _CountOfMasters == 10)
            {
                _CountOfMasters++;
                MessageBox.Show("Майстра найнято, тепер наймайте працівників!");
                return;
            }
            else
            {
                MessageBox.Show("Замало працівників для того, щоб найняти майстра");
            }
        }
        //////  
        public void DismissEmployee() //метод увольнения работника
        {
            if (_CountOfEmployees == 0)
                return;
            _CountOfEmployees--;
            if (_CountOfMasters * 10 - _CountOfEmployees >= 10)
            {
                _CountOfMasters--;
                MessageBox.Show("Було звільнено працівника та майстра, бо забагато майстрів!");
            }
        }
        public void DismissMaster() //метод увольнения мастера
        {
            bool flag = false;
            if (_CountOfMasters == 0)
                return;
            _CountOfMasters--;
            while (_CountOfEmployees - _CountOfMasters * 10 != 0)
            {
                flag = true;
                _CountOfEmployees--;
            }
            if(flag)
                MessageBox.Show("Майстра звільнено!\rВідбулося скорочення працівників, бо на заводі тепер працює замало майстрів!");
        }
        public int CompareTo(Factory obj) //реализация интерфейса IComparable, метод сравнения заводов
        {
            if (obj == null) return 1;
            if (_CountOfDepartment == obj._CountOfDepartment && _MonthBenefitFactoryFromEmployee + _MonthBenefitFactoryFromMaster == obj._MonthBenefitFactoryFromEmployee + obj._MonthBenefitFactoryFromMaster)
            {
                MessageBox.Show("Заводи мають однакову кількість цехів та прибуток!");
                return 0;
            }
            else if (_MonthBenefitFactoryFromEmployee + _MonthBenefitFactoryFromMaster == obj._MonthBenefitFactoryFromEmployee + obj._MonthBenefitFactoryFromMaster)
            {
                MessageBox.Show("Заводи отримують однаковий прибуток!");
                return 0;
            }
            else if (_MonthBenefitFactoryFromEmployee + _MonthBenefitFactoryFromMaster > obj._MonthBenefitFactoryFromEmployee + obj._MonthBenefitFactoryFromMaster)
            {
                MessageBox.Show($"Завод {_FactoryName} має більший прибуток!");
                return 1;
            }
            else
            {
                MessageBox.Show($"Завод {obj._FactoryName} має більший прибуток!");
                return -1;
            }
        }
    }
}
