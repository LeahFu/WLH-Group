   M S B A M L   `   `   `  ????L  HPetAdoptionSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:PetAdoptionSystemPetAdoptionSystem  5   	   #    PetAdoptionSystem.PetAdoption   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:PetAdoptionSystem     5   	     ? Title$  PetAdoption??5   	   $	??450??6   $	??800??6*   ??5	      ?? 5
   
    j? TileMode$
 None=?6    ?? ImageSource$ imgs/background2.jpg??6&    j? Stretch$
 Fill=?6I   .??5      ? .+?5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ dataGrid??5      $
??Left=?6%   $	??Top=?6@      CanUserAddRows$ False??5         
IsReadOnly$
 True??6*      AutoGenerateColumns$ False??6<   $??
350,90,0,0q?5   >   $	??171??6R      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 ID??6%   
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 40 6K   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   ?? *petId+6K     5      $
	 Name??6%   $
 75 6O    63   ?? *	petName+6O     5      $		 Age??6%   $
 40 6M    62   ?? *petAge+6M     5      $	 Gender??6%   $
 50 6S    65   ?? *	petGender+6S     5      $	 Class??6%   $
 75 6Q    64   ?? *
petClass+6Q     5      $	 
isAdoption??6%   $
 70 6X    69   ?? *
isAdoption+6X   5      ?? 5   
   -   5         ??Name$ Pet_ID??5      $??Pet ID :??6    $??Right=?63   $??
0,85,667,0q?6O   $	??Top=?6c   ?? 5   
   -   5         ??Name$ petIdT??5      $
??Left=?6"   $??
153,90,0,0q?6=    ?? TextWrapping$
 Wrap=?6Q   $	??Top=?6e   $	??120??6}   ?? 5   
   -   5        $ Pet_Name??5      $??Name :??6"   $??Right=?63   $??0,115,667,0q?6O   $	??Top=?6d    J? RenderTransformOrigin$ 0.472,1.387&?6|   ?? 5   
   -   5        $ petNameT??5      $
??Left=?6$   $??153,123,0,0q?6?   $
 Wrap=?6T   $	??Top=?6h   $	??120??6?   ?? 5   
   -   5        $ Pet_Age??5      $??Age : ??6!   $??Right=?62   $??0,145,667,0q?6N   $	??Top=?6c   $ -0.107,0.284&?6{   ?? 5   
   -   5        $ petAgeT??5      $
??Left=?6#   $??153,153,0,0q?6>   $
 Wrap=?6S   $	??Top=?6g   $	??120??6   ?? 5   
   -   5        $ 
Pet_Gender??5      $??	Gender : ??6$   $??Right=?68   $??0,175,667,0q?6T   $	??Top=?6i   $ 
0.5,-0.121&?6?   ?? 5    
   -	   5        $ 
petGenderT??5       $
??Left=?6&   $??153,183,0,0q?6A   $
 Wrap=?6V   $	??Top=?6j   $	??120??6?   ?? 5!   
   -
   5        $ 	Pet_Class??5!      $??Class :??6#   $??Right=?65   $??	0,0,667,0q?6Q   $??Center=?6d   $ 
0.55,0.324&?6   ?? 5"   
   -   5        $ 	petClassT??5"      $
??Left=?6%   $??153,213,0,0q?6@   $
 Wrap=?6U   $	??Top=?6i   $	??120??6?   ?? 5#   
   -   5        $ Is_Adoption??5#      $??Is Adoption ???6%   $??Right=?6=   $??0,235,667,0q?6Y   $	??Top=?6n   ?? 5$   
   -   5        $ isAdoptionT??5$      $
??Left=?6'   $??153,243,0,0q?6B   $
 Wrap=?6W   $	??Top=?6k   $	??120??6?   ?? 5%   
   -   5         ??Name$ Adopt??5%      $??Adopt??6    $
??Left=?60   $??150,300,0,0q?6K   $	??Top=?6`   $??25??6x   $??60??6?   6?   ?? 5&   
   -   5        $ Search??5&      $??Search??6!   $
??Left=?62   $??
60,300,0,0q?6M   $	??Top=?6a   $??25??6y   $??60??6?   $ 0.519,-0.559&?6?   ?? 5'   
   -   5        $ ServerStatus??5'      $?? ??6&   $??Right=?61   $??0,269,506,0q?6M   $	??Top=?6b   $	??140??6z   ?? 5(   
   $??Adpotion Management??6   $
??Left=?6.   $??	85,20,0,0q?6I   $	??Top=?6\   $??24(?6t   ?? 5)   
   -   5        $ 	Clear_btn??5)      $??Clear??6$   $
??Left=?64   $??240,300,0,0q?6O   $	??Top=?6d   $??25??6|   $??60??6?   $??14(?6?   6?   ?? 5*   
   -   5        $ MainMenu_btn??5*      $??	Main Menu??6'   $??Right=?6;   $??	0,0,80,50q?6W   $??Bottom=?6j   $??25??6?   $??70??6?   5+      5,      