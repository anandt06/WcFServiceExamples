using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeClientApp
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            EmployeeServiceProxy.EmployeeServiceClient client = new
          EmployeeServiceProxy.EmployeeServiceClient();
            EmployeeServiceProxy.Employee employee = null;

            if (((EmployeeServiceProxy.EmployeeType)Convert.ToInt32(ddlEmployeeType.SelectedValue))
                == EmployeeServiceProxy.EmployeeType.FullTimeEmployee)
            {
                employee = new EmployeeServiceProxy.FullTimeEmployee
                {
                    Id = Convert.ToInt32(txtID.Text),
                    Name = txtName.Text,
                    Gender = txtGender.Text,
                    DateOfBirth = Convert.ToDateTime(txtDateOfBirth.Text),
                    Type = EmployeeServiceProxy.EmployeeType.FullTimeEmployee,
                    AnnualSalary = Convert.ToInt32(txtAnnualSalary.Text),
                  //  City = txtCity.Text
                };
                client.SaveEmployee(employee);
                lblMessage.Text = "Employee saved";
            }
            else if (((EmployeeServiceProxy.EmployeeType)Convert.ToInt32(ddlEmployeeType.SelectedValue))
                == EmployeeServiceProxy.EmployeeType.PartTimeEmployee)
            {
                employee = new EmployeeServiceProxy.PartTimeEmployee
                {
                    Id = Convert.ToInt32(txtID.Text),
                    Name = txtName.Text,
                    Gender = txtGender.Text,
                    DateOfBirth = Convert.ToDateTime(txtDateOfBirth.Text),
                    Type = EmployeeServiceProxy.EmployeeType.PartTimeEmployee,
                    HourlyPay = Convert.ToInt32(txtHourlyPay.Text),
                    HoursWorked = Convert.ToInt32(txtHoursWorked.Text),
                };
                client.SaveEmployee(employee);
                lblMessage.Text = "Employee saved";
            }
            else
            {
                lblMessage.Text = "Please select Employee Type";
            }
        }

        protected void btnGetEmployee_Click(object sender, EventArgs e)
        {
            EmployeeServiceProxy.EmployeeServiceClient client =
       new EmployeeServiceProxy.EmployeeServiceClient();
            EmployeeServiceProxy.Employee employee =
                client.GetEmployee(Convert.ToInt32(txtID.Text));

            if (employee.Type == EmployeeServiceProxy.EmployeeType.FullTimeEmployee)
            {
                txtAnnualSalary.Text =
                    ((EmployeeServiceProxy.FullTimeEmployee)employee).AnnualSalary.ToString();
                trAnnualSalary.Visible = true;
                trHourlPay.Visible = false;
                trHoursWorked.Visible = false;
            }
            else
            {
                txtHourlyPay.Text =
                    ((EmployeeServiceProxy.PartTimeEmployee)employee).HourlyPay.ToString();
                txtHoursWorked.Text =
                    ((EmployeeServiceProxy.PartTimeEmployee)employee).HoursWorked.ToString();
                trAnnualSalary.Visible = false;
                trHourlPay.Visible = true;
                trHoursWorked.Visible = true;
            }
            ddlEmployeeType.SelectedValue = ((int)employee.Type).ToString();



            txtName.Text = employee.Name;
           // txtCity.Text = employee.City;
            txtGender.Text = employee.Gender;
            txtDateOfBirth.Text = employee.DateOfBirth.ToShortDateString();
            lblMessage.Text = "Employee retrieved";
        }

        protected void ddlEmployeeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlEmployeeType.SelectedValue == "-1")
            {
                trAnnualSalary.Visible = false;
                trHourlPay.Visible = false;
                trHoursWorked.Visible = false;
            }
            else if (ddlEmployeeType.SelectedValue == "1")
            {
                trAnnualSalary.Visible = true;
                trHourlPay.Visible = false;
                trHoursWorked.Visible = false;
            }
            else
            {
                trAnnualSalary.Visible = false;
                trHourlPay.Visible = true;
                trHoursWorked.Visible = true;
            }
        }
    }
}