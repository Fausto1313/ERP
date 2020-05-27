<?php

namespace app\models;

use Yii;

class ResLang extends \yii\db\ActiveRecord
{
    public static function tableName()
    {
        return 'res_lang';
    }

    public function rules()
    {
        return [
            [['name', 'code', 'url_code', 'direction', 'date_format', 'time_format', 'week_start', 'grouping', 'decimal_point'], 'required'],
            [['name', 'code', 'iso_code', 'url_code', 'direction', 'date_format', 'time_format', 'week_start', 'grouping', 'decimal_point', 'thousands_sep'], 'string'],
            [['active', 'create_uid', 'write_uid'], 'integer'],
            [['create_date', 'write_date'], 'safe'],
            [['trial477'], 'string', 'max' => 1],
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
            'iso_code' => 'Iso Code',
            'url_code' => 'Url Code',
            'active' => 'Active',
            'direction' => 'Direction',
            'date_format' => 'Date Format',
            'time_format' => 'Time Format',
            'week_start' => 'Week Start',
            'grouping' => 'Grouping',
            'decimal_point' => 'Decimal Point',
            'thousands_sep' => 'Thousands Sep',
            'create_uid' => 'Create Uid',
            'create_date' => 'Create Date',
            'write_uid' => 'Write Uid',
            'write_date' => 'Write Date',
            'trial477' => 'Trial477',
        ];
    }

    /**
     * Gets query for [[CrmLeads]].
     *
     * @return \yii\db\ActiveQuery|CrmLeadQuery
     */
    public function getCrmLeads()
    {
        return $this->hasMany(CrmLead::className(), ['lang_id' => 'id']);
    }

    public function getCreateU()
    {
        return $this->hasOne(ResUsers::className(), ['id' => 'create_uid']);
    }

    public function getWriteU()
    {
        return $this->hasOne(ResUsers::className(), ['id' => 'write_uid']);
    }

    public function getWebsiteVisitors()
    {
        return $this->hasMany(WebsiteVisitor::className(), ['lang_id' => 'id']);
    }

    public static function find()
    {
        return new ResLangQuery(get_called_class());
    }
}
