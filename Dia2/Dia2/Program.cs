using System.Runtime.CompilerServices;

string rutaInput = "F:/Codigo/CodigoDeAdvientoPorquePolvoronesNoMeHacenFalta/Dia2/Dia2/input.txt";
int validReports = 0;

foreach(string linea in File.ReadLines(rutaInput)){

    bool creciente = true;
    bool decreciente = true;
    bool incrementoValido = false;
    bool dampenerUsado = false;
    bool reporteValido = true;

    string[] levelsSplitted = linea.Split(' ', StringSplitOptions.RemoveEmptyEntries); 
    int[] levels = Array.ConvertAll(levelsSplitted,int.Parse);

    for(int i = 1; i < levels.Length; i++){

        if(levels[i] < levels[i-1]){
            creciente = false;
        }
        if(levels[i] > levels[i-1]){
            decreciente = false;
        }

        incrementoValido = CalcularIncrementoValido(levels[i-1], levels[i]);

        if(!creciente && !decreciente && !incrementoValido){
           //Pido perdón
           if(dampenerUsado){
                creciente = false;
                decreciente = false;
                break;  
           }else{
                dampenerUsado = true;

                //reseteamos condiciones y reevaluamos sin este elemento en el array
                creciente = true;
                decreciente = true;
                for(int j =1; j < levels.Length; j++){
                    //skipeamos el elemento que dio problemas
                    if(i==j){
                        continue;
                    }
                    if(levels[j] < levels[j-1]){
                        creciente = false;
                    }
                    if(levels[j] > levels[j-1]){
                        decreciente = false;
                    }

                    //Si sigue sin ser valido salimos
                    if(!creciente && !decreciente){
                        break;
                    }
                }
           }
            
        }
        if(!creciente && !decreciente && !incrementoValido &&dampenerUsado){
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


