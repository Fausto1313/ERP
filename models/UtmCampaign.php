<?php

namespace app\models;

use Yii;
class UtmCampaign extends \yii\db\ActiveRecord
{
    public static function tableName()
    {
        return 'utm_campaign';
    }
    public function rules()
    {
        return [
            [['name', 'user_id', 'stage_id'], 'required'],
            [['name'], 'string'],
            [['user_id', 'stage_id', 'is_website', 'color', 'create_uid', 'write_uid', 'company_id'], 'integer'],
            [['create_date', 'write_date'], 'safe'],
            [['trial562'], 'string', 'max' => 1],
            [['company_id'], 'exist', 'skipOnError' => true, 'targetClass' => ResCompany::className(), 'targetAttribute' => ['company_id' => 'id']],
            [['create_uid'], 'exist', 'skipOnError' => true, 'targetClass' => ResUsers::className(), 'targetAttribute' => ['create_uid' => 'id']],
            [['user_id'], 'exist', 'skipOnError' => true, 'targetClass' => ResUsers::className(), 'targetAttribute' => ['user_id' => 'id']],
            [['write_uid'], 'exist', 'skipOnError' => true, 'targetClass' => ResUsers::className(), 'targetAttribute' => ['write_uid' => 'id']],
        ];
    }

    public function attributeLabels()
    {
        return [
            'id' => 'ID',
            'name' => 'Name',
            'user_id' => 'User ID',
            'stage_id' => 'Stage ID',
            'is_website' => 'Is Website',
            'color' => 'Color',
            'create_uid' => 'Create Uid',
            'create_date' => 'Create Date',
            'write_uid' => 'Write Uid',
            'write_date' => 'Write Date',
            'company_id' => 'Company ID',
            'trial562' => 'Trial562',
        ];
    }

    public function getCrmLeads()
    {
        return $this->hasMany(CrmLead::className(), ['campaign_id' => 'id']);
    }

    public function getSaleOrders()
    {
        return $this->hasMany(SaleOrder::className(), ['campaign_id' => 'id']);
    }

    public function getCompany()
    {
        return $this->hasOne(ResCompany::className(), ['id' => 'company_id']);
    }

    public function getCreateU()
    {
        return $this->hasOne(ResUsers::className(), ['id' => 'create_uid']);
    }

    public function getUser()
    {
        return $this->hasOne(ResUsers::className(), ['id' => 'user_id']);
    }

    public function getWriteU()
    {
        return $this->hasOne(ResUsers::className(), ['id' => 'write_uid']);
    }

    public static function find()
    {
        return new UtmCampaignQuery(get_called_class());
    }
}
