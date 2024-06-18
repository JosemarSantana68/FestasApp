namespace FestasApp.Views.Calendario
{
    public class myLblDiasSemana : Label
    {
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            AutoSize = false;
            Font = new Font("Segoe UI", 10, FontStyle.Regular);
            ForeColor = Color.Black;
            TextAlign = ContentAlignment.MiddleCenter;
        }

    }
}
