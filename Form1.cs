using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MathGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.AddRange(MathGame.MyOperators);
            label22.Hide(); button12.Hide(); textBox41.Hide();
            textBox42.Hide(); label23.Hide(); label24.Hide();
            button13.Hide(); button14.Hide();
        }
        private void button11_Click(object sender, EventArgs e)// выбор операции
        {
            string operation = "";
            for (int i = 1; i <= 37; i += 4)//Очистим текстбокс от старых данных
            {
                this.Controls["textbox" + i.ToString()].Text = null;//
                this.Controls["textbox" + (i + 2).ToString()].Text = null;//
            }
            if (comboBox1.Text == "")//Пока не выбрали оператора, след. элементы не активные
            {
               MessageBox.Show("Не выбрали оператора!");
            }
            else
            {
                if (comboBox1.Text == "Сложение (+)")
                    operation = "+";

                else if (comboBox1.Text == "Вычатание (-)")
                    operation = "-";

                else if (comboBox1.Text == "Умножение (*)")
                    operation = "*";

                else if (comboBox1.Text == "Деление (÷)")
                {
                    operation = "÷";
                    textBox41.Text = Convert.ToString(1);
                    textBox42.Text = Convert.ToString(25);
                    button12.Show();
                }
                label22.Show(); button12.Show();    textBox41.Show();
                textBox42.Show();   label23.Show(); label24.Show();                
                button11.Hide();//После выбора операции, убираем кнопка выбора
                
            }
            for (int i = 2; i <= 38; i += 4)//заполняем тексбокс с выбанной опрации
            {
                this.Controls["textbox" + i.ToString()].Text = operation;
            }           
        }
        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(textBox41.Text) <= 100 && Convert.ToInt32(textBox42.Text) <= 100)//textBox41.Text != "" && textBox42.Text != "")//|| comboBox1.Text == "Деление (÷)")
                {
                    if (comboBox1.Text == "Деление (÷)") //При деление заполняем текстбоксов
                    {
                        for (int i = 1; i <= 37; i += 4)//заполняем делимое и делитель
                        {
                            int divisible = MathGame._myRandom.Next(1, 7);//берем рандомные числа в указанном диапазоне, это число будем использовать как делитель
                            int divider = MathGame._myRandom.Next(1, 7) * divisible;//Делитель умножаем на новое число и получаем днлимое число
                            this.Controls["textbox" + i.ToString()].Text = Convert.ToString(divider);//заполняем тексбоксы делимое
                            this.Controls["textbox" + (i + 2).ToString()].Text = Convert.ToString(divisible);// заполняем тексбоксы делителем
                            
                        }
                        button12.Hide();//После того как все ячейки заполнили спрячем кнопку заполнить
                        button13.Show();
                        textBox41.ReadOnly = true;//Отключаем ввод текста
                        textBox42.ReadOnly = true;
                    }
                    else if (comboBox1.Text == "Вычатание (-)")
                    {
                        for (int i = 1; i <= 37; i += 4)
                        {
                            int reduced = MathGame._myRandom.Next(int.Parse(textBox41.Text), int.Parse(textBox42.Text));//Уменьшаемое
                            int subtractible = MathGame._myRandom.Next(int.Parse(textBox41.Text), int.Parse(textBox42.Text));//Вычитаемое
                            while (reduced - subtractible < 1)
                            {
                                reduced++;

                            }
                            this.Controls["textbox" + i.ToString()].Text =
                                    Convert.ToString(reduced);//заполняем тексбоксы
                            this.Controls["textbox" + (i + 2).ToString()].Text =
                                Convert.ToString(subtractible);// заполняем тексбоксы
                            button12.Hide();
                            button13.Show();
                            textBox41.ReadOnly = true;
                            textBox42.ReadOnly = true;
                        }
                    }
                    else //При + и * заполняем текстбоксов
                    {
                        for (int i = 1; i <= 37; i += 4)
                        {
                            this.Controls["textbox" + i.ToString()].Text =
                                Convert.ToString(MathGame._myRandom.Next(int.Parse(textBox41.Text), int.Parse(textBox42.Text)));//заполняем тексбоксы
                            this.Controls["textbox" + (i + 2).ToString()].Text =
                                Convert.ToString(MathGame._myRandom.Next(int.Parse(textBox41.Text), int.Parse(textBox42.Text)));// заполняем тексбоксы
                        }
                        button12.Hide();//После того как все ячейки заполнили спрячем кнопку заполнить
                        textBox41.ReadOnly = true;
                        textBox42.ReadOnly = true;
                        button13.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Указанное число должен быть меньше 100");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Вы указали не число!!");
            }  
        }
      //с помощью цикла скрываем все задачи кроме 1-го от пользователя  
        private void button13_Click(object sender, EventArgs e)
        {
            int a = 12;
            for (int i = 5; i <= 40; i += 4)
            {
                this.Controls["textbox" + i.ToString()].Hide();
                this.Controls["textbox" + (i + 1).ToString()].Hide();
                this.Controls["textbox" + (i + 2).ToString()].Hide();
                this.Controls["label" + (a).ToString()].Hide();
                this.Controls["textbox" + (i + 3).ToString()].Hide();
                a++;
            }
            button14.Show();
            button13.Hide();
            label25.Text = Convert.ToString(counter1 - 11) + "-я задача";
            //textBox4.ReadOnly = false;
        }
        public int counter = 1;// счетчик для перехода на след тексбокс после проверки
        public int counter1 = 12;//счетчик для label
        public int correctAnswer = 0;//Записываем количество правильных ответов
             
        private void button14_Click(object sender, EventArgs e)
        {
            try// обработка исключение
            {
                //Проверяем ответ при сложение и меняем цвет текстбокса на зеленый или красный зависимо от ответа
                if (comboBox1.Text == "Сложение (+)")
                {
                    bool color = MathGame.CheckingActions(MathGame.MyAddition(this.Controls["textbox" + counter].Text,
                        this.Controls["textbox" + (counter + 2)].Text), this.Controls["textbox" + (counter + 3)].Text);
                    if (color)
                    {
                        this.Controls["textbox" + (counter + 3)].BackColor = Color.Green;
                        correctAnswer++;
                        this.Controls["button" + (counter1 - 11)].BackColor = Color.Green;
                    }
                    else//если не правильно ответили
                    {
                        this.Controls["textbox" + (counter + 3)].BackColor = Color.Red;
                        this.Controls["button" + (counter1 - 11)].BackColor = Color.Red;
                    }
                }
                //Проверяем ответ при вычатание и меняем цвет текстбокса на зеленый или красный зависимо от ответа
                else if (comboBox1.Text == "Вычатание (-)")
                {
                    bool color = MathGame.CheckingActions(MathGame.MySubtraction(this.Controls["textbox" + counter].Text,
                        this.Controls["textbox" + (counter + 2)].Text), this.Controls["textbox" + (counter + 3)].Text);
                    if (color)
                    {
                        this.Controls["textbox" + (counter + 3)].BackColor = Color.Green;
                        correctAnswer++;
                        this.Controls["button" + (counter1 - 11)].BackColor = Color.Green;
                    }
                    else//если не правильно ответили
                    {
                        this.Controls["textbox" + (counter + 3)].BackColor = Color.Red;
                        this.Controls["button" + (counter1 - 11)].BackColor = Color.Red;
                    }
                }
                //Проверяем ответ при умножение и меняем цвет текстбокса на зеленый или красный зависимо от ответа
                else if (comboBox1.Text == "Умножение (*)")
                {
                    bool color = MathGame.CheckingActions(MathGame.MyMultiplication(this.Controls["textbox" + counter].Text,
                        this.Controls["textbox" + (counter + 2)].Text), this.Controls["textbox" + (counter + 3)].Text);
                    if (color)
                    {
                        this.Controls["textbox" + (counter + 3)].BackColor = Color.Green;
                        correctAnswer++;
                        this.Controls["button" + (counter1 - 11)].BackColor = Color.Green;
                    }
                    else//если не правильно ответили
                    {
                        this.Controls["textbox" + (counter + 3)].BackColor = Color.Red;
                        this.Controls["button" + (counter1 - 11)].BackColor = Color.Red;
                    }
                }
                //Проверяем ответ при деление и меняем цвет текстбокса на зеленый или красный зависимо от ответа
                else if (comboBox1.Text == "Деление (÷)")
                {
                    bool color = MathGame.CheckingActions(MathGame.MyDivision(this.Controls["textbox" + counter].Text,
                        this.Controls["textbox" + (counter + 2)].Text), this.Controls["textbox" + (counter + 3)].Text);
                    if (color)// если правильно ответили
                    {
                        this.Controls["textbox" + (counter + 3)].BackColor = Color.Green;
                        correctAnswer++;
                        this.Controls["button" + (counter1 - 11)].BackColor = Color.Green;
                        
                    }
                    else//если не правильно ответили
                    {
                        this.Controls["textbox" + (counter + 3)].BackColor = Color.Red;
                        this.Controls["button" + (counter1 - 11)].BackColor = Color.Red;
                    }
                }
                if (counter < 37)//выполняется пока счетчик меньше 37(то есть пока не выполниться 10-я задача)
                {
                    counter += 4;
                    this.Controls["textbox" + counter.ToString()].Show();
                    this.Controls["textbox" + (counter + 1).ToString()].Show();
                    this.Controls["textbox" + (counter + 2).ToString()].Show();
                    this.Controls["label" + (counter1).ToString()].Show();
                    this.Controls["textbox" + (counter + 3).ToString()].Show();
                    counter1++;
                }
                else//после выполнение 10-й задачи выводиться информация о завершение
                {
                    MessageBox.Show("ИГРА ЗАВЕРШЕНА!!!\nВаша оценка: "+correctAnswer+" из 10");
                    button14.Hide();

                }
                label25.Text = Convert.ToString(counter1 - 11) + "-я задача";
            }
            catch(FormatException)//На случае отсутствие или некорректных ввода
            {
                this.Controls["textbox" + (counter + 3)].BackColor = Color.Orange;
                MessageBox.Show("На "+(counter1 - 11) + "-ю задачу еще не ответили!");  
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }    
}
