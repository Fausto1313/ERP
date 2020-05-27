<?php

namespace app\models;

use Yii;
class ResCountryState extends \yii\db\ActiveRecord
{
    public static function tableName()
    {
        return 'res_country_state';
    }

    public function rules()
    {
        return [
            [['country_id', 'name', 'code'], 'required'],
            [['country_id', 'create_uid', 'write_uid'], 'integer'],
            [['name', 'code'], 'string'],
            [['create_date', 'write_date'], 'safe'],
            [['trial464'], 'string', 'max' => 1],
            [['country_id'], 'exist', 'skipOnError' => true, 'targetClass' => ResCountry::className(), 'targetAttribute' => ['country_id' => 'id']],
            [['create_uid'], 'exist', 'skipOnError' => true, 'targetClass' => ResUsers::className(), 'targetAttribute' => ['create_uid' => 'id']],
            [['write_uid'], 'exist', 'skipOnError' => true, 'targetClass' => ResUsers::className(), 'targetAttribute' => ['write_uid' => 'id']],
        ];
    }

    public function attributeLabels()
    {
        return [
            'id' => 'ID',
            'country_id' => 'Country ID',
            'name' => 'Name',
            'code' => 'Code',
            'create_uid' => 'Create Uid',
            'create_date' => 'Create Date',
            'write_uid' => 'Write Uid',
            'write_date' => 'Write Date',
            'trial464' => 'Trial464',
        ];
    }

    public function getCrmLeads()
    {
        return $this->hasMany(CrmLead::className(), ['state_id' => 'id']);
    }

    public function getCountry()
    {
        return $this->hasOne(ResCountry::className(), ['id' => 'country_id']);
    }

    public function getCreateU()
    {
        return $this->hasOne(ResUsers::className(), ['id' => 'create_uid']);
    }

    public function getWriteU()
    {
        return $this->hasOne(ResUsers::className(), ['id' => 'write_uid']);
    }

    public function getResPartners()
    {
        return $this->hasMany(ResPartner::className(), ['state_id' => 'id']);
    }

    public static function find()
    {
        return new ResCountryStateQuery(get_called_class());
    }
}
