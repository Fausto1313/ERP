<?php

return [
  /* 'class' => 'yii\db\Connection',
   'dsn' => new \yii\db\mssql\PDO('sqlsrv:server=DESKTOP-128IPTR\ERP;database=ERP,"username", "password"'),
  'username' => 'sa',
  'password' => '20763093d',
  'charset' => 'utf8',
  'emulatePrepare'=>'false',
    */
       'class' => 'yii\db\Connection',
    'dsn' => 'mysql:host=localhost:3306;dbname=ERP',
    'username' => 'root',
    'password' => '',
    'charset' => 'utf8',
/*   'yii/db'=>array(

	'class'=>'CDbConnection',

	'connectionString'=>'sqlsrv:host=DESKTOP-128IPTR\ERP;port=1433;dbname=ERP',

	'username'=>'sa',

	'password'=>'20763093d',

	'charset' => 'utf8',

'emulatePrepare'=>'false'),
*/    // Schema cache options (for production environment)
    //'enableSchemaCache' => true,
    //'schemaCacheDuration' => 60,
    //'schemaCache' => 'cache',

    
];

