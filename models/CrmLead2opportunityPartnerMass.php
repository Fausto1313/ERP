<?php

namespace app\models;

use Yii;

class CrmLead2opportunityPartnerMass extends \yii\db\ActiveRecord
{
    public static function tableName()
    {
        return 'crm_lead2opportunity_partner_mass';
    }

    public function rules()
    {
        return [
            [['team_id', 'deduplicate', 'force_assignation', 'user_id', 'partner_id', 'create_uid', 'write_uid'], 'integer'],
            [['action', 'name'], 'required'],
            [['action', 'name'], 'string'],
            [['create_date', 'write_date'], 'safe'],
            [['trial274'], 'string', 'max' => 1],
            [['create_uid'], 'exist', 'skipOnError' => true, 'targetClass' => ResUsers::className(), 'targetAttribute' => ['create_uid' => 'id']],
            [['partner_id'], 'exist', 'skipOnError' => true, 'targetClass' => ResPartner::className(), 'targetAttribute' => ['partner_id' => 'id']],
            [['team_id'], 'exist', 'skipOnError' => true, 'targetClass' => CrmTeam::className(), 'targetAttribute' => ['team_id' => 'id']],
            [['user_id'], 'exist', 'skipOnError' => true, 'targetClass' => ResUsers::className(), 'targetAttribute' => ['user_id' => 'id']],
            [['write_uid'], 'exist', 'skipOnError' => true, 'targetClass' => ResUsers::className(), 'targetAttribute' => ['write_uid' => 'id']],
        ];
    }

    public function attributeLabels()
    {
        return [
            'id' => 'ID',
            'team_id' => 'Team ID',
            'deduplicate' => 'Deduplicate',
            'action' => 'Action',
            'force_assignation' => 'Force Assignation',
            'name' => 'Name',
            'user_id' => 'User ID',
            'partner_id' => 'Partner ID',
            'create_uid' => 'Create Uid',
            'create_date' => 'Create Date',
            'write_uid' => 'Write Uid',
            'write_date' => 'Write Date',
            'trial274' => 'Trial274',
        ];
    }

    public function getCreateU()
    {
        return $this->hasOne(ResUsers::className(), ['id' => 'create_uid']);
    }

    public function getPartner()
    {
        return $this->hasOne(ResPartner::className(), ['id' => 'partner_id']);
    }

    public function getTeam()
    {
        return $this->hasOne(CrmTeam::className(), ['id' => 'team_id']);
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
        return new CrmLead2opportunityPartnerMassQuery(get_called_class());
    }
}
