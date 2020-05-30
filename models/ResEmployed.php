<?php

namespace app\models;

use Yii;


class ResEmployed extends \yii\db\ActiveRecord
{
    public static function tableName()
    {
        return 'res_employed';
    }
/**Se declaran las reglas de cadacampo si en la base no estan declarados cuales son requeridos en este apartado se puede hacer
 * tambien se pueden agregar leyendas al no rellenar los campos**/
    public function rules()
    {
        return [
            [['Id_Comp'], 'required'],
            [['Id_Comp', 'E_Nomina', 'ID_Partner'], 'integer'],
            [['F_Creacion'], 'safe'],
            [['N_Empleado'], 'string', 'max' => 30],
            [['E_Apellidos'], 'string', 'max' => 100],
            [['ID_Partner'], 'exist', 'skipOnError' => true, 'targetClass' => ResPartner::className(), 'targetAttribute' => ['ID_Partner' => 'id']],
        ];
    }
/*Por nomenclatura se utilizan terminos en ingles, guiones bajos
para no mostrar tal cual el atributo este lo parseamos y cambiamos */
    public function attributeLabels()
    {
        return [
            'Id' => 'ID',
            'Id_Comp' => 'Compañia',
            'N_Empleado' => 'Nombre Empleado',
            'E_Apellidos' => 'Apellidos',
            'E_Nomina' => 'Numero de Nomina',
            'F_Creacion' => 'Fecha de Creacion',
            'ID_Partner' => 'Cliente',
        ];
    }
/**En este apartado tenemos las relaciones entre tablas Id corresponde a la tabla Res_Partner y ID_Partner corresponde a res_employed**/
    public function getPartner()
    {
        return $this->hasOne(ResPartner::className(), ['id' => 'ID_Partner']);
    }

    public static function find()
    {
        return new ResEmployedQuery(get_called_class());
    }
    /*En este apartado hago referencia a la llave primaria de employed y a la foranea rescompany*/
    public function getCompani()
    {
        return $this->hasOne(ResCompany::className(), ['partner_id' => 'Id_comp']);
    }

}
