<?php

namespace app\models;

use Yii;

/**
 * This is the model class for table "mail_alias".
 *
 * @property int $id TRIAL
 * @property string|null $alias_name TRIAL
 * @property int $alias_model_id TRIAL
 * @property int|null $alias_user_id TRIAL
 * @property string $alias_defaults TRIAL
 * @property int|null $alias_force_thread_id TRIAL
 * @property int|null $alias_parent_model_id TRIAL
 * @property int|null $alias_parent_thread_id TRIAL
 * @property string $alias_contact TRIAL
 * @property int|null $create_uid TRIAL
 * @property string|null $create_date TRIAL
 * @property int|null $write_uid TRIAL
 * @property string|null $write_date TRIAL
 * @property string|null $trial353 TRIAL
 *
 * @property CrmTeam[] $crmTeams
 * @property ResUsers $aliasUser
 * @property ResUsers $createU
 * @property ResUsers $writeU
 * @property ResUsers[] $resUsers
 */
class MailAlias extends \yii\db\ActiveRecord
{
    /**
     * {@inheritdoc}
     */
    public static function tableName()
    {
        return 'mail_alias';
    }

    /**
     * {@inheritdoc}
     */
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

    /**
     * {@inheritdoc}
     */
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

    /**
     * Gets query for [[CrmTeams]].
     *
     * @return \yii\db\ActiveQuery|CrmTeamQuery
     */
    public function getCrmTeams()
    {
        return $this->hasMany(CrmTeam::className(), ['alias_id' => 'id']);
    }

    /**
     * Gets query for [[AliasUser]].
     *
     * @return \yii\db\ActiveQuery|ResUsersQuery
     */
    public function getAliasUser()
    {
        return $this->hasOne(ResUsers::className(), ['id' => 'alias_user_id']);
    }

    /**
     * Gets query for [[CreateU]].
     *
     * @return \yii\db\ActiveQuery|ResUsersQuery
     */
    public function getCreateU()
    {
        return $this->hasOne(ResUsers::className(), ['id' => 'create_uid']);
    }

    /**
     * Gets query for [[WriteU]].
     *
     * @return \yii\db\ActiveQuery|ResUsersQuery
     */
    public function getWriteU()
    {
        return $this->hasOne(ResUsers::className(), ['id' => 'write_uid']);
    }

    /**
     * Gets query for [[ResUsers]].
     *
     * @return \yii\db\ActiveQuery|ResUsersQuery
     */
    public function getResUsers()
    {
        return $this->hasMany(ResUsers::className(), ['alias_id' => 'id']);
    }

    /**
     * {@inheritdoc}
     * @return MailAliasQuery the active query used by this AR class.
     */
    public static function find()
    {
        return new MailAliasQuery(get_called_class());
    }
}
