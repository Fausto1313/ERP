<?php

namespace app\models;

use Yii;
class ResCountry extends \yii\db\ActiveRecord
{
    public static function tableName()
    {
        return 'res_country';
    }

    public function rules()
    {
        return [
            [['name'], 'required'],
            [['name', 'address_format', 'name_position', 'vat_label'], 'string'],
            [['address_view_id', 'currency_id', 'phone_code', 'create_uid', 'write_uid'], 'integer'],
            [['create_date', 'write_date'], 'safe'],
            [['code'], 'string', 'max' => 2],
            [['trial434'], 'string', 'max' => 1],
            [['code'], 'unique'],
            [['create_uid'], 'exist', 'skipOnError' => true, 'targetClass' => ResUsers::className(), 'targetAttribute' => ['create_uid' => 'id']],
            [['write_uid'], 'exist', 'skipOnError' => true, 'targetClass' => ResUsers::className(), 'targetAttribute' => ['write_uid' => 'id']],
        ];
    }

    public function attributeLabels()
    {
        return [
            'id' => 'ID',
            'name' => 'Name',
            'code' => 'Code',
            'address_format' => 'Address Format',
            'address_view_id' => 'Address View ID',
            'currency_id' => 'Currency ID',
            'phone_code' => 'Phone Code',
            'name_position' => 'Name Position',
            'vat_label' => 'Vat Label',
            'create_uid' => 'Create Uid',
            'create_date' => 'Create Date',
            'write_uid' => 'Write Uid',
            'write_date' => 'Write Date',
            'trial434' => 'Trial434',
        ];
    }

    public function getCrmLeads()
    {
        return $this->hasMany(CrmLead::className(), ['country_id' => 'id']);
    }

    public function getCreateU()
    {
        return $this->hasOne(ResUsers::className(), ['id' => 'create_uid']);
    }
    public function getWriteU()
    {
        return $this->hasOne(ResUsers::className(), ['id' => 'write_uid']);
    }

    public function getResCountryStates()
    {
        return $this->hasMany(ResCountryState::className(), ['country_id' => 'id']);
    }

    public function getResPartners()
    {
        return $this->hasMany(ResPartner::className(), ['country_id' => 'id']);
    }

    public function getWebsiteVisitors()
    {
        return $this->hasMany(WebsiteVisitor::className(), ['country_id' => 'id']);
    }

    public static function find()
    {
        return new ResCountryQuery(get_called_class());
    }
}
