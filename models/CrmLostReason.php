<?php

namespace app\models;

use Yii;

class CrmLostReason extends \yii\db\ActiveRecord
{
    public static function tableName()
    {
        return 'crm_lost_reason';
    }

    public function rules()
    {
        return [
            [['name'], 'required'],
            [['name'], 'string'],
            [['active', 'create_uid', 'write_uid'], 'integer'],
            [['create_date', 'write_date'], 'safe'],
            [['trial291'], 'string', 'max' => 1],
            [['create_uid'], 'exist', 'skipOnError' => true, 'targetClass' => ResUsers::className(), 'targetAttribute' => ['create_uid' => 'id']],
            [['write_uid'], 'exist', 'skipOnError' => true, 'targetClass' => ResUsers::className(), 'targetAttribute' => ['write_uid' => 'id']],
        ];
    }

    public function attributeLabels()
    {
        return [
            'id' => 'ID',
            'name' => 'Name',
            'active' => 'Active',
            'create_uid' => 'Create Uid',
            'create_date' => 'Create Date',
            'write_uid' => 'Write Uid',
            'write_date' => 'Write Date',
            'trial291' => 'Trial291',
        ];
    }

    public function getCrmLeads()
    {
        return $this->hasMany(CrmLead::className(), ['lost_reason' => 'id']);
    }

    public function getCreateU()
    {
        return $this->hasOne(ResUsers::className(), ['id' => 'create_uid']);
    }

    public function getWriteU()
    {
        return $this->hasOne(ResUsers::className(), ['id' => 'write_uid']);
    }

    public static function find()
    {
        return new CrmLostReasonQuery(get_called_class());
    }
}
