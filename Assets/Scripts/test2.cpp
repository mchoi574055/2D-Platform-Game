#include <iostream>
#include <iomanip> //to allow for setprecision and fixed
using namespace std;

int main() {
    //Initial variables for input to be stored into
    float initialInvAmt = 0.0;
    float monthlyDeposit = 0.0;
    float annualCmpdInt = 0.0; //annual compounded interest
    int numYears = 0;

    int numMonths = 12;
    float openingAmount = initialInvAmt;
    float totalAmt = openingAmount + monthlyDeposit;
    float monCmpdInt = (openingAmount + monthlyDeposit) * ((annualCmpdInt / 100) / 12);  //monthly compounded interest
    float yearEndBalance1 = 0.0;
    float yearEndBalance2 = 0.0;
    float interestAmt = 0.0;

    float closingBalance = totalAmt + (totalAmt * monCmpdInt);

    // needed to run program again
    string continueAnswer;

    // begin outer loop
    do {
        bool passOrFail = true;
        cout << "**********************************" << endl;
        cout << "********Data Input****************" << endl;

        //for inputting initial investment amount
        do {
            cin.clear(); //in case an error occurs to clear the cin.
            cout << "Initial Investment Amount:        ";
            cin >>  initialInvAmt;

            if (cin.fail() || initialInvAmt <= 0.0) { //if the cin fails to read the type that is expected
                cin.clear();
                cin.ignore(100, '
');
                cout << "Invalid input, please enter a positive number." <<endl;
                passOrFail = false;
            }
            else {
                passOrFail = true;
            }
        } while (passOrFail == false); //continue the loop while cin.fail() or initialInvAmt <= 0.0

        //for inputting Monthly Deposit amount
        do {
            cin.clear(); //in case an error occurs to clear the cin.
            cout << "Monthly Deposit:                  ";
            cin >> monthlyDeposit;

            if (cin.fail() || monthlyDeposit <= 0.0) { //if the cin fails to read the type that is expected
                cin.clear();
                cin.ignore(100, '
');
                cout << "Invalid input, please enter a positive number." <<endl;
                passOrFail = false;
            }
            else {
                passOrFail = true;
            }
        } while (passOrFail == false); //continue the loop while cin.fail() or initialInvAmt <= 0.0

                //for inputting Monthly Deposit amount
        do {
            cin.clear(); //in case an error occurs to clear the cin.
            cout << "Annual Interest:                  ";
            cin >> annualCmpdInt;

            if (cin.fail() || annualCmpdInt <= 0.0) { //if the cin fails to read the type that is expected
                cin.clear();
                cin.ignore(100, '
');
                cout << "Invalid input, please enter a positive number." << endl;
                passOrFail = false;
            }
            else {
                passOrFail = true;
            }
        } while (passOrFail == false); //continue the loop while cin.fail() or initialInvAmt <= 0.0
        
                //for inputting Monthly Deposit amount
        do {
            cin.clear(); //in case an error occurs to clear the cin.
            cout << "Number of Years:                  ";
            cin >> numYears;

            if (cin.fail() || numYears <= 0) { //if the cin fails to read the type that is expected
                cin.clear();
                cin.ignore(100, '
');
                cout << "Invalid input, please enter a positive number (no decimal point numbers)" << endl;
                passOrFail = false;
            }
            else {
                passOrFail = true;
            }
        } while (passOrFail == false); //continue the loop while cin.fail() or initialInvAmt <= 0.0

        system("PAUSE"); 
        
        //report 1 process:
        cout << "    Balance and Interest With Additional Monthly Deposits       " << endl;
        cout << "==============================================================  " << endl;
        cout << "Year        Year End Balance          Year End Earned Interest  " << endl;
        cout << "--------------------------------------------------------------  " << endl;
        
        yearEndBalance1 = initialInvAmt; //make initialInvAmt the first value in yearEndBalance
        for (int year = 1; year <= numYears; year++) { //to iterate through the years
            //calculate the yearly interest
            interestAmt = yearEndBalance1 * (annualCmpdInt/100); 

            //update the balance:
            yearEndBalance1 += interestAmt; // will show in the next year.

            //output:
            cout << year << "              " << fixed << setprecision(2) << yearEndBalance1 << "                     " << interestAmt << endl;
        }
        //report 2 process:

        cout << "    Balance and Interest With Additional Monthly Deposits       " << endl;
        cout << "==============================================================  " << endl;
        cout << "Year        Year End Balance          Year End Earned Interest  " << endl;
        cout << "--------------------------------------------------------------  " << endl;

        yearEndBalance2 = initialInvAmt; //make initialInvAmt the first value in yearEndBalance
        for (int year = 1; year <= numYears; year++) { //to iterate through the years
            //calculate the yearly interest
          for (int month = 1; month <= numMonths; month++) {
            interestAmt += (yearEndBalance2 + monthlyDeposit) *((annualCmpdInt/100)/12);
            yearEndBalance2 += monthlyDeposit + interestAmt; // will show in the next year.
          }
        }

            //output:
            cout << year << "              " << fixed << setprecision(2) << yearEndBalance2 << "                     " << interestAmt << endl;
        }








        cout << "Would you like to input different values (Y or N)";
        cin >> continueAnswer;
        while (continueAnswer != "Y" && continueAnswer != "N") { //this works once, then pauses then ends
            cout << "Invalid input, please enter either Y for yes or N for no (case-sensitive)" << endl;
            cin >> continueAnswer;
        }
    } while (continueAnswer == "Y"); //needs to be revised infinite loop
    return 0;
}