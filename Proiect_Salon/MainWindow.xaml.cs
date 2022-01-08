using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SalonCModel;




namespace Proiect_Salon
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    enum ActionState
    {
        New,
        Edit,
        Delete,
        Nothing
    }
    public partial class MainWindow : Window
    {
        ActionState action = ActionState.Nothing;
        SalonCEntitiesModel ctx = new SalonCEntitiesModel();
        CollectionViewSource clientiVSource;
        CollectionViewSource angajatiVSource;
        CollectionViewSource inventarVSource;
        CollectionViewSource serviciiVSource;


        CollectionViewSource clientiProgramaresVSource;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            clientiVSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("clientiViewSource")));
            clientiVSource.Source = ctx.Clientis.Local;
            ctx.Clientis.Load();

            clientiProgramaresVSource =
((System.Windows.Data.CollectionViewSource)(this.FindResource("clientiProgramaresViewSource")));
           clientiProgramaresVSource.Source = ctx.Programares.Local;
          // ctx.Programares.Load();

            

            //cmbClienti.ItemsSource = ctx.Clientis.Local;
            //cmbClienti.DisplayMemberPath = "Data";
            cmbClienti.SelectedValuePath = "Id_Client";

            cmbAngajati.ItemsSource = ctx.Angajatis.Local;
            //cmbAngajati.DisplayMemberPath = "Nume";
            cmbAngajati.SelectedValuePath = "Id_Angajat";


            System.Windows.Data.CollectionViewSource clientiViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("clientiViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // clientiViewSource.Source = [generic data source]

            angajatiVSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("angajatiViewSource")));
            angajatiVSource.Source = ctx.Angajatis.Local;
            ctx.Angajatis.Load();

            System.Windows.Data.CollectionViewSource angajatiViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("angajatiViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // angajatiViewSource.Source = [generic data source]
           
            inventarVSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("inventarViewSource")));
            inventarVSource.Source = ctx.Inventars.Local;
            ctx.Inventars.Load();

            System.Windows.Data.CollectionViewSource inventarViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("inventarViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // inventarViewSource.Source = [generic data source]

            

            System.Windows.Data.CollectionViewSource programareViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("programareViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // programareViewSource.Source = [generic data source]

            serviciiVSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("serviciiViewSource")));
            serviciiVSource.Source = ctx.Serviciis.Local;
            ctx.Serviciis.Load();
            System.Windows.Data.CollectionViewSource serviciiViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("serviciiViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // serviciiViewSource.Source = [generic data source]
            
            //BindDataGrid();

        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            action = ActionState.New;
        }
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            action = ActionState.Edit;
        }
        private void btnNextC_Click(object sender, RoutedEventArgs e)
        {
            clientiVSource.View.MoveCurrentToNext();
        }
        private void btnPreviousC_Click(object sender, RoutedEventArgs e)
        {
            clientiVSource.View.MoveCurrentToPrevious();
        }
        private void SaveClientis()
        {
            Clienti clienti = null;
            if (action == ActionState.New)
            {
                try
                {
                    //instantiem Customer entity
                    clienti = new Clienti()
                    {
                        Email = emailTextBox.Text.Trim(),
                        Nume = numeTextBox.Text.Trim(),
                        Prenume = prenumeTextBox.Text.Trim(),
                        Telefon = int.Parse(telefonTextBox.Text.Trim()),
                    };
                    //adaugam entitatea nou creata in context
                    ctx.Clientis.Add(clienti);
                    clientiVSource.View.Refresh();
                    //salvam modificarile
                    ctx.SaveChanges();
                }
                //using System.Data;
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
           if (action == ActionState.Edit)
            {
                try
                {
                    clienti = (Clienti)clientiDataGrid.SelectedItem;
                    clienti.Email = emailTextBox.Text.Trim();
                    clienti.Nume = numeTextBox.Text.Trim();
                    clienti.Prenume = prenumeTextBox.Text.Trim();
                    clienti.Telefon = int.Parse(telefonTextBox.Text.Trim());
                    //salvam modificarile
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (action == ActionState.Delete)
            {
                try
                {
                    clienti = (Clienti)clientiDataGrid.SelectedItem;
                    ctx.Clientis.Remove(clienti);
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                clientiVSource.View.Refresh();
            }

        }

        private void telefonTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void clientiDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnNextA_Click(object sender, RoutedEventArgs e)
        {
            clientiVSource.View.MoveCurrentToNext();
        }
        private void btnPreviousA_Click(object sender, RoutedEventArgs e)
        {
            clientiVSource.View.MoveCurrentToPrevious();
        }
        private void SaveAngajatis()
        {
            Angajati angajati = null;
            if (action == ActionState.New)
            {
                try
                {
                    //instantiem Customer entity
                    angajati = new Angajati()
                    {
                       
                        Nume = numeTextBox.Text.Trim(),
                        Prenume = prenumeTextBox.Text.Trim(),
                       
                    };
                    //adaugam entitatea nou creata in context
                    ctx.Angajatis.Add(angajati);
                    angajatiVSource.View.Refresh();
                    //salvam modificarile
                    ctx.SaveChanges();
                }
                //using System.Data;
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
           if (action == ActionState.Edit)
            {
                try
                {
                    angajati = (Angajati)angajatiDataGrid.SelectedItem;

                    angajati.Nume = numeTextBox.Text.Trim();
                    angajati.Prenume = prenumeTextBox.Text.Trim();
                    
                    //salvam modificarile
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (action == ActionState.Delete)
            {
                try
                {
                    angajati = (Angajati)angajatiDataGrid.SelectedItem;
                    ctx.Angajatis.Remove(angajati);
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                clientiVSource.View.Refresh();
            }

        }
        private void btnNextI_Click(object sender, RoutedEventArgs e)
        {
            clientiVSource.View.MoveCurrentToNext();
        }
        private void btnPreviousI_Click(object sender, RoutedEventArgs e)
        {
            clientiVSource.View.MoveCurrentToPrevious();
        }
        private void SaveInventars()
        {
            Inventar inventar = null;
            if (action == ActionState.New)
            {
                try
                {
                    //instantiem Customer entity
                    inventar = new Inventar()
                    {

                        Nume_Produs = nume_ProdusTextBox.Text.Trim(),
                        Stoc_Curent  = int.Parse(stoc_CurentTextBox.Text.Trim()),
                        Stoc_minim  = int.Parse(stoc_minimTextBox.Text.Trim())

                    };
                    //adaugam entitatea nou creata in context
                    ctx.Inventars.Add(inventar);
                    inventarVSource.View.Refresh();
                    //salvam modificarile
                    ctx.SaveChanges();
                }
                //using System.Data;
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
           if (action == ActionState.Edit)
            {
                try
                {
                    inventar = (Inventar)inventarDataGrid.SelectedItem;

                    inventar.Nume_Produs = nume_ProdusTextBox.Text.Trim();
                    inventar.Stoc_Curent = int.Parse(stoc_CurentTextBox.Text.Trim());
                    inventar.Stoc_minim = int.Parse(stoc_minimTextBox.Text.Trim());

                    //salvam modificarile
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (action == ActionState.Delete)
            {
                try
                {
                   
                    inventar = (Inventar)inventarDataGrid.SelectedItem;
                    ctx.Inventars.Remove(inventar);
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                inventarVSource.View.Refresh();
            }

        }


        private void btnNextS_Click(object sender, RoutedEventArgs e)
        {
            clientiVSource.View.MoveCurrentToNext();
        }
        private void btnPreviousS_Click(object sender, RoutedEventArgs e)
        {
            serviciiVSource.View.MoveCurrentToPrevious();
        }
        private void SaveServiciis()
        {
            Servicii servicii = null;
            if (action == ActionState.New)
            {
                try
                {
                    //instantiem Customer entity
                    servicii = new Servicii()
                    {

                        
                        Pret = int.Parse(pretTextBox.Text.Trim()),
                        Tip_Serviciu = tip_ServiciuTextBox.Text.Trim()

                    };
                    //adaugam entitatea nou creata in context
                    ctx.Serviciis.Add(servicii);
                    serviciiVSource.View.Refresh();
                    //salvam modificarile
                    ctx.SaveChanges();
                }
                //using System.Data;
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
           if (action == ActionState.Edit)
            {
                try
                {
                    servicii = (Servicii)serviciiDataGrid.SelectedItem;

                    servicii.Pret = int.Parse(pretTextBox.Text.Trim());
                    servicii.Tip_Serviciu = tip_ServiciuTextBox.Text.Trim();
                    

                    //salvam modificarile
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (action == ActionState.Delete)
            {
                try
                {
                    servicii = (Servicii)serviciiDataGrid.SelectedItem;
                    ctx.Serviciis.Remove(servicii);
                    ctx.SaveChanges();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                inventarVSource.View.Refresh();
            }

        }


       
        private void gbOperations_Click(object sender, RoutedEventArgs e)
        {
            Button SelectedButton = (Button)e.OriginalSource;
            Panel panel = (Panel)SelectedButton.Parent;

            foreach (Button B in panel.Children.OfType<Button>())
            {
                if (B != SelectedButton)
                    B.IsEnabled = false;
            }
            gbActions.IsEnabled = true;
        }


        private void SaveProgramares()
        {
            Programare programare = null;
            if (action == ActionState.New)
            {
                try
                {
                    Clienti clienti = (Clienti)cmbClienti.SelectedItem;
                    Angajati angajati = (Angajati)cmbAngajati.SelectedItem;
                    //instantiem Order entity 
                    programare = new Programare()
                    {

                        Id_Client = clienti.Id,
                        Id_Angajat = angajati.Id
                    };
                    //adaugam entitatea nou creata in context
                    ctx.Programares.Add(programare);
                    //salvam modificarile
                    ctx.SaveChanges();
                    BindDataGrid();
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
           if (action == ActionState.Edit)
            {
                dynamic selectedProgramare = programaresDataGrid.SelectedItem;
                try
                {
                    int curr_id = selectedProgramare.Id;
                    var editedProgramare = ctx.Programares.FirstOrDefault(s => s.Id == curr_id);
                    if (editedProgramare != null)
                    {
                        editedProgramare.Id_Client = Int32.Parse(cmbClienti.SelectedValue.ToString());
                        editedProgramare.Id_Angajat = Convert.ToInt32(cmbAngajati.SelectedValue.ToString());
                        //salvam modificarile
                        ctx.SaveChanges();
                    }
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
                BindDataGrid();
                // pozitionarea pe item-ul curent
                clientiProgramaresVSource.View.MoveCurrentTo(selectedProgramare);
            }
            else if (action == ActionState.Delete)
            {
                try
                {
                    dynamic selectedProgramare = programaresDataGrid.SelectedItem;
                    int curr_id = selectedProgramare.Id;
                    var deletedProgramare = ctx.Programares .FirstOrDefault(s => s.Id == curr_id);
                    if (deletedProgramare != null)
                    {
                        ctx.Programares.Remove(deletedProgramare);
                        ctx.SaveChanges();
                        MessageBox.Show("Programare stearsa cu succes", "Message");
                        BindDataGrid();
                    }
                }
                catch (DataException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

       

        private void ReInitialize()
        {

            Panel panel = gbOperations.Content as Panel;
            foreach (Button B in panel.Children.OfType<Button>())
            {
                B.IsEnabled = true;
            }
            gbActions.IsEnabled = false;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            ReInitialize();
        }

        
        private void BindDataGrid()
        {
            var queryProgramare = from pro in ctx.Programares

                             join clie in ctx.Clientis on pro.Id_Client equals
                             clie.Id
                             join ang in ctx.Angajatis on pro.Id_Angajat
                 equals ang.Id
                             select new
                             {
                                 pro.Id,
                                 pro.Id_Angajat,
                                 pro.Id_Client,
                                 clie.Nume,
                                 clie.Prenume,
                                // ang.Nume,
                                // ang.Prenume
                             };
            clientiProgramaresVSource.Source = queryProgramare.ToList();
        }

        private void cmbAngajati_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }

}
