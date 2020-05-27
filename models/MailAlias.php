<?php

namespace app\models;

use Yii;
class MailAlias extends \yii\db\ActiveRecord
{
    public static function tableName()
    {
        return 'mail_alias';
    }

    public function rules()
    {
        return [
            [['alias_name', 'alias_defaults', 'alias_contact'], 'string'],
            [['alias_model_id', 'alias_defaults', 'alias_contact'], 'required'],
            [['alias_model_id', 'alias_user_id', 'alias_force_thread_id', 'alias_parent_model_id', 'alias_parent_thread_id', 'create_uid', 'write_uid'], 'integer'],
            [['create_date', 'write_date'], 'safe'],
            [['trial353'], 'string', 'max' => 1],
            [['alias_user_id'], 'exist', 'skipOnError' => true, 'targetClass' => ResUsers::className(), 'targetAttribute' => ['alias_user_id' => 'id']],
            [['create_uid'], 'exist', 'skipOnError' => true, 'targetClass' => ResUsers::className(), 'targetAttribute' => ['create_uid' => 'id']],
            [['write_uid'], 'exist', 'skipOnError' => true, 'targetClass' => ResUsers::className(), 'targetAttribute' => ['write_uid' => 'id']],
        ];
    }

    public function attributeLabels()
    {
        return [
            'id' => 'ID',
            'alias_name' => 'Alias Name',
            'alias_model_id' => 'Alias Model ID',
            'alias_user_id' => 'Alias User ID',
            'alias_defaults' => 'Alias Defaults',
            'alias_force_thread_id' => 'Alias Force Thread ID',
            'alias_parent_model_id' => 'Alias Parent Model ID',
            'alias_parent_thread_id' => 'Alias Parent Thread ID',
            'alias_contact' => 'Alias Contact',
            'create_uid' => 'Create Uid',
            'create_date' => 'Create Date',
            'write_uid' => 'Write Uid',
            'write_date' => 'Write Date',
            'trial353' => 'Trial353',
        ];
    }

    public function getCrmTeams()
    {
        return $this->hasMany(CrmTeam::className(), ['alias_id' => 'id']);
    }

    public function getAliasUser()
    {
        return $this->hasOne(ResUsers::className(), ['id' => 'alias_user_id']);
    }

    public function getCreateU()
    {
        return $this->hasOne(ResUsers::className(), ['id' => 'create_uid']);
    }

    public function getWriteU()
    {
        return $this->hasOne(ResUsers::className(), ['id' => 'write_uid']);
    }

    public function getResUsers()
    {
        return $this->hasMany(ResUsers::className(), ['alias_id' => 'id']);
    }

    public static function find()
    {
        return new MailAliasQuery(get_called_class());
    }
}
