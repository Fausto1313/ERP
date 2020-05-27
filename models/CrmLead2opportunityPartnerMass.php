<?php

namespace app\models;

use Yii;

/**
 * This is the model class for table "crm_lead2opportunity_partner_mass".
 *
 * @property int $id TRIAL
 * @property int|null $team_id TRIAL
 * @property int|null $deduplicate TRIAL
 * @property string $action TRIAL
 * @property int|null $force_assignation TRIAL
 * @property string $name TRIAL
 * @property int|null $user_id TRIAL
 * @property int|null $partner_id TRIAL
 * @property int|null $create_uid TRIAL
 * @property string|null $create_date TRIAL
 * @property int|null $write_uid TRIAL
 * @property string|null $write_date TRIAL
 * @property string|null $trial274 TRIAL
 *
 * @property ResUsers $createU
 * @property ResPartner $partner
 * @property CrmTeam $team
 * @property ResUsers $user
 * @property ResUsers $writeU
 */
class CrmLead2opportunityPartnerMass extends \yii\db\ActiveRecord
{
    /**
     * {@inheritdoc}
     */
    public static function tableName()
    {
        return 'crm_lead2opportunity_partner_mass';
    }

    /**
     * {@inheritdoc}
     */
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

    /**
     * {@inheritdoc}
     */
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
     * Gets query for [[Partner]].
     *
     * @return \yii\db\ActiveQuery|ResPartnerQuery
     */
    public function getPartner()
    {
        return $this->hasOne(ResPartner::className(), ['id' => 'partner_id']);
    }

    /**
     * Gets query for [[Team]].
     *
     * @return \yii\db\ActiveQuery|CrmTeamQuery
     */
    public function getTeam()
    {
        return $this->hasOne(CrmTeam::className(), ['id' => 'team_id']);
    }

    /**
     * Gets query for [[User]].
     *
     * @return \yii\db\ActiveQuery|ResUsersQuery
     */
    public function getUser()
    {
        return $this->hasOne(ResUsers::className(), ['id' => 'user_id']);
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
     * {@inheritdoc}
     * @return CrmLead2opportunityPartnerMassQuery the active query used by this AR class.
     */
    public static function find()
    {
        return new CrmLead2opportunityPartnerMassQuery(get_called_class());
    }
}
