using System.Runtime.CompilerServices;

string rutaInput = "F:/Codigo/CodigoDeAdvientoPorquePolvoronesNoMeHacenFalta/Dia2/Dia2/input.txt";
int validReports = 0;

foreach(string linea in File.ReadLines(rutaInput)){

    bool creciente = true;
    bool decreciente = true;
    bool incrementoValido = false;


    string[] levelsSplitted = linea.Split(' ', StringSplitOptions.RemoveEmptyEntries); 
    int[] levels = Array.ConvertAll(levelsSplitted,int.Parse);

    for(int i = 1; i < levels.Length; i++){

        if(levels[i] < levels[i-1]){
            creciente = false;
        }
        if(levels[i] > levels[i-1]){
            decreciente = false;
        }
        if(!creciente && !decreciente){
            break;
        }

        incrementoValido = CalcularIncrementoValido(levels[i-1], levels[i]);
        if(!incrementoValido){
            break;
        }
        
    }

    if(incrementoValido && (creciente || decreciente)){
            validReports ++;
    }

}

static bool CalcularIncrementoValido(int anterior, int actual){

    if(Math.Abs(anterior - actual) == 0 || Math.Abs(anterior - actual) > 3){
        return false;
    }
    return true;
}

Console.WriteLine($"Deberían ser {validReports} reports validos.");


