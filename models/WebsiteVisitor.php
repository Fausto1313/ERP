<?php

namespace app\models;

use Yii;
class WebsiteVisitor extends \yii\db\ActiveRecord
{
    public static function tableName()
    {
        return 'website_visitor';
    }

    public function rules()
    {
        return [
            [['name', 'access_token', 'timezone'], 'string'],
            [['access_token'], 'required'],
            [['active', 'website_id', 'partner_id', 'country_id', 'lang_id', 'visit_count', 'create_uid', 'write_uid', 'livechat_operator_id'], 'integer'],
            [['create_date', 'last_connection_datetime', 'write_date'], 'safe'],
            [['trial588'], 'string', 'max' => 1],
            [['partner_id'], 'unique'],
            [['country_id'], 'exist', 'skipOnError' => true, 'targetClass' => ResCountry::className(), 'targetAttribute' => ['country_id' => 'id']],
            [['create_uid'], 'exist', 'skipOnError' => true, 'targetClass' => ResUsers::className(), 'targetAttribute' => ['create_uid' => 'id']],
            [['lang_id'], 'exist', 'skipOnError' => true, 'targetClass' => ResLang::className(), 'targetAttribute' => ['lang_id' => 'id']],
            [['livechat_operator_id'], 'exist', 'skipOnError' => true, 'targetClass' => ResPartner::className(), 'targetAttribute' => ['livechat_operator_id' => 'id']],
            [['partner_id'], 'exist', 'skipOnError' => true, 'targetClass' => ResPartner::className(), 'targetAttribute' => ['partner_id' => 'id']],
            [['write_uid'], 'exist', 'skipOnError' => true, 'targetClass' => ResUsers::className(), 'targetAttribute' => ['write_uid' => 'id']],
        ];
    }

    public function attributeLabels()
    {
        return [
            'id' => 'ID',
            'name' => 'Name',
            'access_token' => 'Access Token',
            'active' => 'Active',
            'website_id' => 'Website ID',
            'partner_id' => 'Partner ID',
            'country_id' => 'Country ID',
            'lang_id' => 'Lang ID',
            'timezone' => 'Timezone',
            'visit_count' => 'Visit Count',
            'create_date' => 'Create Date',
            'last_connection_datetime' => 'Last Connection Datetime',
            'create_uid' => 'Create Uid',
            'write_uid' => 'Write Uid',
            'write_date' => 'Write Date',
            'livechat_operator_id' => 'Livechat Operator ID',
            'trial588' => 'Trial588',
        ];
    }

    public function getCountry()
    {
        return $this->hasOne(ResCountry::className(), ['id' => 'country_id']);
    }

    public function getCreateU()
    {
        return $this->hasOne(ResUsers::className(), ['id' => 'create_uid']);
    }

    public function getLang()
    {
        return $this->hasOne(ResLang::className(), ['id' => 'lang_id']);
    }

    public function getLivechatOperator()
    {
        return $this->hasOne(ResPartner::className(), ['id' => 'livechat_operator_id']);
    }

    public function getPartner()
    {
        return $this->hasOne(ResPartner::className(), ['id' => 'partner_id']);
    }

    public function getWriteU()
    {
        return $this->hasOne(ResUsers::className(), ['id' => 'write_uid']);
    }

    public static function find()
    {
        return new WebsiteVisitorQuery(get_called_class());
    }
}
