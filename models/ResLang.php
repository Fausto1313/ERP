<?php

namespace app\models;

use Yii;

/**
 * This is the model class for table "res_lang".
 *
 * @property int $id TRIAL
 * @property string $name TRIAL
 * @property string $code TRIAL
 * @property string|null $iso_code TRIAL
 * @property string $url_code TRIAL
 * @property int|null $active TRIAL
 * @property string $direction TRIAL
 * @property string $date_format TRIAL
 * @property string $time_format TRIAL
 * @property string $week_start TRIAL
 * @property string $grouping TRIAL
 * @property string $decimal_point TRIAL
 * @property string|null $thousands_sep TRIAL
 * @property int|null $create_uid TRIAL
 * @property string|null $create_date TRIAL
 * @property int|null $write_uid TRIAL
 * @property string|null $write_date TRIAL
 * @property string|null $trial477 TRIAL
 *
 * @property CrmLead[] $crmLeads
 * @property ResUsers $createU
 * @property ResUsers $writeU
 * @property WebsiteVisitor[] $websiteVisitors
 */
class ResLang extends \yii\db\ActiveRecord
{
    /**
     * {@inheritdoc}
     */
    public static function tableName()
    {
        return 'res_lang';
    }

    /**
     * {@inheritdoc}
     */
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

    /**
     * {@inheritdoc}
     */
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
     * Gets query for [[WebsiteVisitors]].
     *
     * @return \yii\db\ActiveQuery|WebsiteVisitorQuery
     */
    public function getWebsiteVisitors()
    {
        return $this->hasMany(WebsiteVisitor::className(), ['lang_id' => 'id']);
    }

    /**
     * {@inheritdoc}
     * @return ResLangQuery the active query used by this AR class.
     */
    public static function find()
    {
        return new ResLangQuery(get_called_class());
    }
}
