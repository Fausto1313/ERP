<?php

namespace app\models;

use Yii;
class CrmStage extends \yii\db\ActiveRecord
{
    public static function tableName()
    {
        return 'crm_stage';
    }

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

    public function getCrmLeads()
    {
        return $this->hasMany(CrmLead::className(), ['stage_id' => 'id']);
    }

    public function getCreateU()
    {
        return $this->hasOne(ResUsers::className(), ['id' => 'create_uid']);
    }

    public function getTeam()
    {
        return $this->hasOne(CrmTeam::className(), ['id' => 'team_id']);
    }

    public function getWriteU()
    {
        return $this->hasOne(ResUsers::className(), ['id' => 'write_uid']);
    }

    public static function find()
    {
        return new CrmStageQuery(get_called_class());
    }
}
