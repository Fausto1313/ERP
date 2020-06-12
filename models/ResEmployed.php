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
            [['E_Nomina', 'ID_Partner', 'codigo_postal'], 'integer'],
            [['F_Creacion', 'birthday'], 'safe'],
            [['Id_Comp', 'active', 'gender', 'marital', 'street', 'department_id', 'ciudad', 'country_id','work_phone', 'mobile_phone', 'work_email', 'work_location'], 'string'],
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
            'active' => 'Estatus',
            'gender' => 'Genero',
            'marital' => 'Estado civil',
            'birthday' => 'Cumpleaños',
            'department_id' => 'Departamento',
            'street' => 'Calle',
            'codigo_postal' => 'Codigo Postal',
            'ciudad' => 'Ciudad',
            'country_id' => 'Pais',
            'work_phone' => 'Telefono de Oficina',
            'mobile_phone' => 'Telefono personal',
            'work_email' => 'Email de oficina',
            'work_location' => 'Lugar de trabajo',
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
        return $this->hasOne(ResCompany::className(), ['name' => 'Id_comp']);
    }

    public function getDepartment()
    {
        return $this->hasOne(ResEmployedDepartment::className(), ['name' => 'department_id']);
    }


    public function getCountry()
    {
        return $this->hasOne(ResCountry::className(), ['name' => 'country_id']);
    }

}
