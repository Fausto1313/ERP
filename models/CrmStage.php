<?php

namespace app\models;

use Yii;

/**
 * This is the model class for table "crm_stage".
 *
 * @property int $id TRIAL
 * @property string $name TRIAL
 * @property int|null $sequence TRIAL
 * @property int|null $is_won TRIAL
 * @property string|null $requirements TRIAL
 * @property int|null $team_id TRIAL
 * @property int|null $fold TRIAL
 * @property int|null $create_uid TRIAL
 * @property string|null $create_date TRIAL
 * @property int|null $write_uid TRIAL
 * @property string|null $write_date TRIAL
 * @property string|null $trial297 TRIAL
 *
 * @property CrmLead[] $crmLeads
 * @property ResUsers $createU
 * @property CrmTeam $team
 * @property ResUsers $writeU
 */
class CrmStage extends \yii\db\ActiveRecord
{
    /**
     * {@inheritdoc}
     */
    public static function tableName()
    {
        return 'crm_stage';
    }

    /**
     * {@inheritdoc}
     */
    public function rules()
    {
        return [
            [['name'], 'required'],
            [['name', 'requirements'], 'string'],
            [['sequence', 'is_won', 'team_id', 'fold', 'create_uid', 'write_uid'], 'integer'],
            [['create_date', 'write_date'], 'safe'],
            [['trial297'], 'string', 'max' => 1],
            [['create_uid'], 'exist', 'skipOnError' => true, 'targetClass' => ResUsers::className(), 'targetAttribute' => ['create_uid' => 'id']],
            [['team_id'], 'exist', 'skipOnError' => true, 'targetClass' => CrmTeam::className(), 'targetAttribute' => ['team_id' => 'id']],
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
            'name' => 'Name',
            'sequence' => 'Sequence',
            'is_won' => 'Is Won',
            'requirements' => 'Requirements',
            'team_id' => 'Team ID',
            'fold' => 'Fold',
            'create_uid' => 'Create Uid',
            'create_date' => 'Create Date',
            'write_uid' => 'Write Uid',
            'write_date' => 'Write Date',
            'trial297' => 'Trial297',
        ];
    }

    /**
     * Gets query for [[CrmLeads]].
     *
     * @return \yii\db\ActiveQuery|CrmLeadQuery
     */
    public function getCrmLeads()
    {
        return $this->hasMany(CrmLead::className(), ['stage_id' => 'id']);
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
     * Gets query for [[Team]].
     *
     * @return \yii\db\ActiveQuery|CrmTeamQuery
     */
    public function getTeam()
    {
        return $this->hasOne(CrmTeam::className(), ['id' => 'team_id']);
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
     * @return CrmStageQuery the active query used by this AR class.
     */
    public static function find()
    {
        return new CrmStageQuery(get_called_class());
    }
}
