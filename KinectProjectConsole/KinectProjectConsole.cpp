// KinectProjectConsole.cpp : Este arquivo contém a função 'main'. A execução do programa começa e termina ali.
//

#include <iostream>
#include<iomanip>
#include <Windows.h>
#include <NuiApi.h>

using namespace std;
int main()
{
    NuiInitialize(NUI_INITIALIZE_FLAG_USES_SKELETON);
    NUI_SKELETON_FRAME ourframe;

    double rightHand = 0;
    double leftHand = 0;

    while (1)
    {
        NuiSkeletonGetNextFrame(0, &ourframe);

        for (int i = 0; i < 6; i++)
        {
            if (ourframe.SkeletonData[i].eTrackingState == NUI_SKELETON_TRACKED) {
                rightHand = ourframe.SkeletonData[i].SkeletonPositions[NUI_SKELETON_POSITION_HAND_RIGHT].x * 10;
                printf("Hand X\n\n");

                printf("Right: %f\n", rightHand);
            }
                
            if (ourframe.SkeletonData[i].eTrackingState == NUI_SKELETON_TRACKED) {
                leftHand = ourframe.SkeletonData[i].SkeletonPositions[NUI_SKELETON_POSITION_HAND_LEFT].x * 10;
                printf("Left: %f\n", leftHand); 
            }        
           
            
           
            
           
        }
        system("cls");
    }
    NuiShutdown();
    return 0;
}

// Executar programa: Ctrl + F5 ou Menu Depurar > Iniciar Sem Depuração
// Depurar programa: F5 ou menu Depurar > Iniciar Depuração

// Dicas para Começar: 
//   1. Use a janela do Gerenciador de Soluções para adicionar/gerenciar arquivos
//   2. Use a janela do Team Explorer para conectar-se ao controle do código-fonte
//   3. Use a janela de Saída para ver mensagens de saída do build e outras mensagens
//   4. Use a janela Lista de Erros para exibir erros
//   5. Ir Para o Projeto > Adicionar Novo Item para criar novos arquivos de código, ou Projeto > Adicionar Item Existente para adicionar arquivos de código existentes ao projeto
//   6. No futuro, para abrir este projeto novamente, vá para Arquivo > Abrir > Projeto e selecione o arquivo. sln
