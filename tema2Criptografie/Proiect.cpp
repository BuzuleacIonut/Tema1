#include <iostream>
#include <string>
#include <cmath>

using namespace std;

int caracter_int(char c) {
    if (c >= '0' && c <= '9') {
        return c - '0';
    }
    else if (c >= 'A' && c <= 'Q') {
        return c - 'A' + 10;
    }
    return -1; 
}


char int_caracter(int val) {
    if (val >= 0 && val <= 9) {
        return '0' + val;
    }
    else if (val >= 10 && val <= 25) {
        return 'A' + val - 10;
    }
    return '\0'; 
}


int convertinb10(string& numar, int baza) {
    int rezultat = 0;
    int putere = 0;
    for (int i = numar.size() - 1; i >= 0; --i) {
        int cifra = caracter_int(numar[i]);
        if (cifra == -1 || cifra >= baza) {
            cout<< "Numar invalid pentru baza data\n";
            return -1;
        }
        rezultat += cifra * pow(baza, putere);
        ++putere;
    }
    return rezultat;
}


string convertdinb10(int numar, int baza) {
    string rezultat = "";
    while (numar > 0) {
        rezultat = int_caracter(numar % baza) + rezultat;
        numar /= baza;
    }
    return rezultat;
}

int main() {
    string numar;
    int baza1, baza2;

    
    cout << "Introduceti numarul: ";
    cin >> numar;
    cout << "Introduceti baza initiala: ";
    cin >> baza1;
    cout << "Introduceti baza finala: ";
    cin >> baza2;

    
    int numarDecimal = convertinb10(numar, baza1);
    if (numarDecimal != -1) {
        string rezultat = convertdinb10(numarDecimal, baza2);
        cout << "Rezultatul in baza " << baza2 << " este: " << rezultat << std::endl;
    }

    return 0;
}