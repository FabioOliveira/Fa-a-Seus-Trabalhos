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



namespace FacaSeusTrabalhos
{
    public partial class MainPage : PhoneApplicationPage
    {
        
        
        public MainPage()
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
            Trabalhos novoTrabalho = new Trabalhos
            {
                Descricao = txtToDo.Text,
                Realizada = false
            };

            novoTrabalho.Gravar();


            txtToDo.Text = string.Empty;
            AtualizarTrabalhos();
           
           
        }
        private void Remove_Tap(object sender, EventArgs e)
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

        
        


        //private void Lembrete()
        //{
           
        //        var schedule = ScheduledActionService.Find("Lembrete");
                
        //            Reminder reminder = new Reminder("Lembrete")
        //            {
        //                BeginTime = DateTime.Now.AddSeconds(5),
        //                Title = "Lembre",
        //                Content = "Voce tem trabalhos a serem feitos...",
        //                RecurrenceType = RecurrenceInterval.None,
                        
        //            };

        //            if (schedule == null)
        //            {
        //                ScheduledActionService.Add(reminder);
        //            }
                
                        
                  
            

        }

        //public void percorrerLembrete()
        //{
        //    Trabalhos pTrabalho = DataContext as Trabalhos;
        //    foreach (Trabalhos tt in pTrabalho.Realizada) {
        //        Lembrete();
        //    }
        //}

        //private void CheckBox_Checked(object sender, RoutedEventArgs e)
        //{
        //    var check = sender as CheckBox;
        //    if (check != null)
        //    {
        //        Trabalhos t = check.DataContext as Trabalhos;
        //        t.Realizada = true;
        //    }
        //}

        //private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        //{
        //    var check = sender as CheckBox;
        //    if (check != null)
        //    {
        //        Trabalhos t = check.DataContext as Trabalhos;
        //        t.Realizada = false;
        //    }
        //}

      //  private void Reminder(object sender, EventArgs e)
      //  {
            
      //          Reminder reminder = new Reminder(name);
      //          reminder.Title = titleTextBox.Text;
      //          reminder.Content = contentTextBox.Text;
      //          reminder.BeginTime = beginTime;
      //          reminder.ExpirationTime = expirationTime;
      //          reminder.RecurrenceType = recurrence;
      //          reminder.NavigationUri = navigationUri;

                
      //          ScheduledActionService.Add(reminder);
      //}
        }


       
  