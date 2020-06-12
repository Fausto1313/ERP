<?php

namespace app\models;

use Yii;

class ResEmployedDepartment extends \yii\db\ActiveRecord
{
    public static function tableName()
    {
        return 'res_employed_department';
    }

    public function rules()
    {
        return [
            [['name', 'complete_name', 'note'], 'string'],
            [['company_id', 'active', 'parent_id', 'manager_id'], 'integer'],
            [['create_date'], 'safe'],
            [['company_id'], 'exist', 'skipOnError' => true, 'targetClass' => ResCompany::className(), 'targetAttribute' => ['company_id' => 'id']],
        ];
    }

    public function attributeLabels()
    {
        return [
            'id' => 'ID',
            'name' => 'Nombre',
            'complete_name' => 'Nombre completo',
            'create_date' => 'Fecha de Creacion',
            'display_name' => 'Display Name',
            'active' => 'Estatus',
            'company_id' => 'Compañía',
            'parent_id' => 'Cliente',
            'manager_id' => 'Líder',
            'note' => 'Nota',
            'create_date' => 'Fecha de Creación',
            
        ];
    }
   
    public function getCompany()
    {
        return $this->hasOne(ResCompany::className(), ['id' => 'company_id']);
    }
      

    
    public function getPartner()
    {
        return $this->hasOne(ResPartner::className(), ['id' => 'parent_id']);
    }

   
}
