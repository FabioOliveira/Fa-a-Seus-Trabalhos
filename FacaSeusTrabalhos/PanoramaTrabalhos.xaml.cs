using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Data.Linq;
using System.Collections.ObjectModel;
using System.ComponentModel;
using FacaSeusTrabalhos.Resources;
using FacaSeusTrabalhos.Model;
using Microsoft.Phone.Scheduler;
using Microsoft.Phone.Shell;

namespace FacaSeusTrabalhos
{
    public partial class PanoramaTrabalhos : PhoneApplicationPage
    {
        
        public PanoramaTrabalhos()
        {


            InitializeComponent();

            AtualizarTrabalhos();

        }

        private void AtualizarTrabalhos()
        {
            Trabalhos objTarefa = new Trabalhos();
            toDoList.ItemsSource = objTarefa.ObtemTrabalhos();
        }

        private void txtToDo_ActionIconTapped(object sender, EventArgs e)
        {



       
            String name = System.Guid.NewGuid().ToString();

            //data inicial
            DateTime date = (DateTime)beginDatePicker.Value;
            DateTime time = (DateTime)beginTimePicker.Value;
            DateTime beginTime = date + time.TimeOfDay;

            bool val1 = false;

            if (beginTime < DateTime.Now)
            {
                MessageBox.Show("Hora inicial invalida ");
                return;
            }
            else {  val1 = true; }
            //data final
            date = (DateTime)expirationDatePicker.Value;
            time = (DateTime)expirationTimePicker.Value;
            DateTime expirationTime = date + time.TimeOfDay;

            
            

            bool val2 = false;

            if (expirationTime < beginTime)
            {
                MessageBox.Show("Data de entrega deve vir depois da inicial");
                return;
            }
            else { val2 = true; }

            if (val1==true && val2==true) { 
            var recurrence = RecurrenceInterval.Daily;


            //adiciona lembrete
            Reminder reminder = new Reminder(name);
            reminder.Title = txtToDo.Text;
            reminder.Content = "Voce tem trabalhos a serem feitos...";
            reminder.BeginTime = beginTime;
            reminder.ExpirationTime = expirationTime;
            reminder.RecurrenceType = recurrence
;

            //adiciona alarme
            Alarm alarm = new Alarm(name);
            alarm.Content = "Voce tem trabalhos a serem feitos...";
            // alarm.Sound = new Uri("/Ringtones/Ring01.wma", UriKind.Relative);
            alarm.BeginTime = beginTime;
            alarm.ExpirationTime = expirationTime;
            alarm.RecurrenceType = recurrence;
            
            




            ScheduledActionService.Add(alarm);

            string data = expirationDatePicker.ToString();

            Trabalhos novoTrabalho = new Trabalhos
            {
                Descricao = txtToDo.Text,
                DataEntrega = data,
                Realizada = false
            };

            novoTrabalho.Gravar();
            txtToDo.Text = string.Empty;
            AtualizarTrabalhos();
                

            
            }
            else {
                MessageBox.Show("Data ou hora invalida");
                return;
            }
            

        }

        private void ToDo_Click(object sender, RoutedEventArgs e)
        {
            var t = sender as CheckBox;
            if (t != null)
            {
                Trabalhos trabalho = t.DataContext as Trabalhos;
                trabalho.Realizado();
                AtualizarTrabalhos();
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            var check = sender as CheckBox;
        if (check != null)
        {
            Trabalhos t = check.DataContext as Trabalhos;
            t.Realizada = true;
        }
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
             var check = sender as CheckBox;
        if (check != null)
        {
            Trabalhos t = check.DataContext as Trabalhos;
            t.Realizada = false;
        }
        }


        private void Remove_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            {
                var t = sender as Image;
                if (t != null)
                {
                    Trabalhos trabalho = t.DataContext as Trabalhos;
                    trabalho.Excluir();
                    AtualizarTrabalhos();
                    
                }
            }
        }



    }
   
}

