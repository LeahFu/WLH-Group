   M S B A M L   `   `   `  ????L  HPetAdoptionSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:PetAdoptionSystemPetAdoptionSystem  5   	   &     PetAdoptionSystem.UserManagement   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:PetAdoptionSystem     5   	     ? Title$  UserManagement??5   	   $	??450??6    $	??800??6-   ??5	      ?? 5
   
    j? TileMode$
 None=?6    ?? ImageSource$ imgs/background2.jpg??6&    j? Stretch$
 Fill=?6I   .??5      ? .+?5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ DataGrid_User??5      $	??465??6U   $	??203??6a      AutoGenerateColumns$ False??6n   $??
280,90,0,0q?5      $
??Left=?6'   $	??Top=?6B      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ User ID??6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 6Q   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 66   ?? *UserId+6Q     5      $ 	User Name??6%   $ 70 6U   	 68   ?? *
UserName+6U     5      $ Password??6%   $ 70 6S   	 67   ?? *	UserPwd+6S     5      $ Address??6%   $	 100 6V   	 66   ?? *UserAddress+6V     5      $	 Age??6%   $ 35 6N   	 62   ?? *	UserAge+6N     5      $ Email??6%   $ 75 6R   	 64   ?? *	UserEmail+6R     5      $ IsAdmin??6%   $ 55 6R   	 66   ?? *	IsAdmin+6R   5      ?? 5   
   -   5        
 ??Name$
 AddUser_btn??5      $	??Add??6&   $
??Left=?64   $??
60,317,0,0q?6O   $	??Top=?6c   $??25??6{   $??60??6?   $??14(?6?   6?   ?? 5   
   -   5        $
 DeleteUser_btn??5      $??Delete??6)   $
??Left=?6:   $??150,356,0,0q?6U   $	??Top=?6j   $??25??6?   $??60??6?   $??14(?6?   6?   ?? 5   
   -   5        $
 MainMenu_btn??5      $??	Main Menu??6'   $??Right=?6;   $??	0,0,80,50q?6W   $??Bottom=?6j   $??25??6?   $??70??6?   ?? 5   
   $??User Management??6   $
??Left=?6*   $??	85,20,0,0q?6E   $	??Top=?6X   $??24(?6p   ?? 5   
   $??	User Id :??6   $??Right=?6$   $??
0,84,676,0q?6@   $	??Top=?6T   ?? 5   
   $??User Name :??6   $??Right=?6&   $??0,115,676,0q?6B   $	??Top=?6W   ?? 5    
   $??
Password :??6   $??Right=?6%   $??0,148,676,0q?6A   $	??Top=?6V   ?? 5!   
   $??	Address :??6   $??Right=?6$   $??0,179,676,0q?6@   $	??Top=?6U   ?? 5"   
   $??Age :??6   $??Right=?6    $??0,211,676,0q?6<   $	??Top=?6Q   ?? 5#   
   $??Email :??6   $??Right=?6"   $??0,242,676,0q?6>   $	??Top=?6S   ?? 5$   
   $??
Is Admin :??6   $??Right=?6%   $??0,268,676,0q?6A   $	??Top=?6V   $??65??6n   ?? 5%   
   -   5         ??Name$ 
UserID_tbx??5%      $
??Left=?6&   $??
129,88,0,0q?6A    ?? TextWrapping$
 Wrap=?6U   $	??Top=?6i   $	??130??6?   ?? 5&   
   -   5        $ UserName_tbx??5&      $
??Left=?6(   $??129,119,0,0q?6C   $
 Wrap=?6X   $	??Top=?6l   $	??130??6?   ?? 5'   
   -   5        $ UserPwd_tbx??5'      $
??Left=?6'   $??129,152,0,0q?6B   $
 Wrap=?6W   $	??Top=?6k   $	??130??6?   ?? 5(   
   -   5        $ UserAdd_tbx??5(      $
??Left=?6'   $??129,183,0,0q?6B   $
 Wrap=?6W   $	??Top=?6k   $	??130??6?   ?? 5)   
   -	   5        $ UserAge_tbx??5)      $
??Left=?6'   $??129,215,0,0q?6B   $
 Wrap=?6W   $	??Top=?6k   $	??130??6?   ?? 5*   
   -
   5        $ UserEmail_tbx??5*      $
??Left=?6)   $??129,246,0,0q?6D   $
 Wrap=?6Y   $	??Top=?6m   $	??130??6?   ?? 5+   
   -   5        $ UserIsAdmin_tbx??5+      $
??Left=?6+   $??129,272,0,0q?6F   $
 Wrap=?6[   $	??Top=?6o   $	??130??6?   ?? 5,   
   -   5        $
 SearchUser_btn??5,      $??Search??6)   $
??Left=?6:   $??
60,356,0,0q?6U   $	??Top=?6i   $??25??6?   $??60??6?   $??14(?6?   6?   ?? 5-   
   -   5        $
 UpdateUser_btn??5-      $??Update??6)   $
??Left=?6:   $??150,317,0,0q?6U   $	??Top=?6j   $??25??6?   $??60??6?   $??14(?6?   6?   ?? 5.   
   -   5        $
 	Clear_btn??5.      $??Clear??6$   $
??Left=?64   $??240,317,0,0q?6O   $	??Top=?6d   $??25??6|   $??60??6?   $??14(?6?   6?   ?? 5/   
   -   5        $
 
ReLoad_btn??5/      $??Reload??6%   $
??Left=?66   $??240,356,0,0q?6Q   $	??Top=?6f   $??25??6~   $??60??6?   $??14(?6?   6?   51      52      