namespace SalesApp
{
    using SalesApp.Data;
    using SalesApp.Models;
    using System;
    using System.Linq;
    using System.Windows.Forms;

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.GetLists();
        }

        private void GetLists()
        {
            using (var context = new SalesContext())
            {
                salesPersonBindingSource.DataSource = context.People
                    .Where(e => e.Active)
                    .OrderBy(e => e.FirstName)
                    .ThenBy(e => e.LastName)
                    .ToList();

                salesRegionBindingSource.DataSource = context.Regions
                    .Where(e => e.Active)
                    .OrderBy(e => e.Name)
                    .ToList();
            }
        }

        private void GetSales()
        {
            var personnId = (int)peopleComboBox.SelectedValue;
            var regionId = (int)regionComboBox.SelectedValue;
            using (var context = new SalesContext())
            {
                saleBindingSource.DataSource = context.Sales
                    .Where(s => s.PersonId == personnId &&
                                s.RegionId == regionId)
                    .OrderBy(s => s.Date)
                    .ToList();
            }
        }

        private void NewSaleButton_Click(object sender, EventArgs e)
        {
            var personnId = (int)peopleComboBox.SelectedValue;
            var regionId = (int)regionComboBox.SelectedValue;

            var sale = new Sale
            {
                Amount = newAmountNumericUpDown.Value,
                Date = newDateDateTimePicker.Value,
                PersonId = personnId,
                RegionId = regionId
            };

            using (var context = new SalesContext())
            {
                context.Sales.Add(sale);
                var result = context.SaveChanges();
                MessageBox.Show($"{result} sales created.");
                GetSales();
            }
        }

        private void RefreshSalesButton_Click(object sender, EventArgs e)
        {
            GetSales();
        }

        private void SalesDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                var salesId = (int)salesDataGridView.Rows[e.RowIndex].Cells[0].Value;
                var amount = (decimal)salesDataGridView.Rows[e.RowIndex].Cells[1].Value;

                var personnId = (int)peopleComboBox.SelectedValue;
                using (var context = new SalesContext())
                {
                    var sale = context.Sales
                        .SingleOrDefault(s => s.Id == salesId);
                    if (sale != null)
                    {
                        sale.Amount = amount;
                        var result = context.SaveChanges();
                        MessageBox.Show($"{result} sales updated.");
                        GetSales();
                    }
                }
            }
        }

        private void SalesDataGridView_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("Delete sale?", "Delete", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }

            var salesId = (int)e.Row.Cells[0].Value;

            var personnId = (int)peopleComboBox.SelectedValue;
            using (var context = new SalesContext())
            {
                var sale = context.Sales
                    .SingleOrDefault(s => s.Id == salesId);
                if (sale != null)
                {
                    context.Sales.Remove(sale);
                    var result = context.SaveChanges();
                    MessageBox.Show($"{result} sales deleted.");
                }
            }
        }

        private void SalesTargetButton_Click(object sender, EventArgs e)
        {
            var personnId = (int)peopleComboBox.SelectedValue;
            using (var context = new SalesContext())
            {
                var person = context.People
                    .SingleOrDefault(p => p.Id == personnId);
                if (person != null)
                {
                    MessageBox.Show($"{person.FullName} has a sales target of {person.SalesTarget:C}");
                }
            }
        }
    }
}
