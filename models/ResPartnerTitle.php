<?php

namespace app\models;

use Yii;

class ResPartnerTitle extends \yii\db\ActiveRecord
{
    public static function tableName()
    {
        return 'res_partner_title';
    }

    public function rules()
    {
        return [
            [['name'], 'required'],
            [['name', 'shortcut'], 'string'],
            [['create_uid', 'write_uid'], 'integer'],
            [['create_date', 'write_date'], 'safe'],
            [['trial522'], 'string', 'max' => 1],
            [['create_uid'], 'exist', 'skipOnError' => true, 'targetClass' => ResUsers::className(), 'targetAttribute' => ['create_uid' => 'id']],
            [['write_uid'], 'exist', 'skipOnError' => true, 'targetClass' => ResUsers::className(), 'targetAttribute' => ['write_uid' => 'id']],
        ];
    }

    public function attributeLabels()
    {
        return [
            'id' => 'ID',
            'name' => 'Name',
            'shortcut' => 'Shortcut',
            'create_uid' => 'Create Uid',
            'create_date' => 'Create Date',
            'write_uid' => 'Write Uid',
            'write_date' => 'Write Date',
            'trial522' => 'Trial522',
        ];
    }

    public function getCrmLeads()
    {
        return $this->hasMany(CrmLead::className(), ['title' => 'id']);
    }

    public function getResPartners()
    {
        return $this->hasMany(ResPartner::className(), ['title' => 'id']);
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
        return new ResPartnerTitleQuery(get_called_class());
    }
}
