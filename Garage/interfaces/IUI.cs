interface IUI
{
    double AskForDouble(string query = "", string successFeedback = "");
    FuelType AskForFuelType();
    uint AskForUint(string query = "", string successFeedback = "");
    Tuple<string, string, uint, string> AskForVehicleDetails();
    UserAction ShowMainMenu();

    string AskForRegNr();
    string AskForVehicleType(bool permitAny = false);
    string AskForColorToSearchFor();
    uint? AskForWheelCountToSearchFor();
}
