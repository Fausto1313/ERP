<?php

return [
  'class' => 'yii\db\Connection',
   'dsn' => new \yii\db\mssql\PDO('sqlsrv:server=DESKTOP-128IPTR:1433\ERP;database=ERP,"username", "password"'),
  'username' => 'sa',
  'password' => '20763093d',
  'charset' => 'utf8',
  'emulatePrepare'=>'false',
    
];

