<?php

namespace app\models;

use Yii;

/**
 * This is the model class for table "res_country_state".
 *
 * @property int $id TRIAL
 * @property int $country_id TRIAL
 * @property string $name TRIAL
 * @property string $code TRIAL
 * @property int|null $create_uid TRIAL
 * @property string|null $create_date TRIAL
 * @property int|null $write_uid TRIAL
 * @property string|null $write_date TRIAL
 * @property string|null $trial464 TRIAL
 *
 * @property CrmLead[] $crmLeads
 * @property ResCountry $country
 * @property ResUsers $createU
 * @property ResUsers $writeU
 * @property ResPartner[] $resPartners
 */
class ResCountryState extends \yii\db\ActiveRecord
{
    /**
     * {@inheritdoc}
     */
    public static function tableName()
    {
        return 'res_country_state';
    }

    /**
     * {@inheritdoc}
     */
    public function rules()
    {
        return [
            [['country_id', 'name', 'code'], 'required'],
            [['country_id', 'create_uid', 'write_uid'], 'integer'],
            [['name', 'code'], 'string'],
            [['create_date', 'write_date'], 'safe'],
            [['trial464'], 'string', 'max' => 1],
            [['country_id'], 'exist', 'skipOnError' => true, 'targetClass' => ResCountry::className(), 'targetAttribute' => ['country_id' => 'id']],
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
            'country_id' => 'Country ID',
            'name' => 'Name',
            'code' => 'Code',
            'create_uid' => 'Create Uid',
            'create_date' => 'Create Date',
            'write_uid' => 'Write Uid',
            'write_date' => 'Write Date',
            'trial464' => 'Trial464',
        ];
    }

    /**
     * Gets query for [[CrmLeads]].
     *
     * @return \yii\db\ActiveQuery|CrmLeadQuery
     */
    public function getCrmLeads()
    {
        return $this->hasMany(CrmLead::className(), ['state_id' => 'id']);
    }

    /**
     * Gets query for [[Country]].
     *
     * @return \yii\db\ActiveQuery|ResCountryQuery
     */
    public function getCountry()
    {
        return $this->hasOne(ResCountry::className(), ['id' => 'country_id']);
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
     * Gets query for [[ResPartners]].
     *
     * @return \yii\db\ActiveQuery|ResPartnerQuery
     */
    public function getResPartners()
    {
        return $this->hasMany(ResPartner::className(), ['state_id' => 'id']);
    }

    /**
     * {@inheritdoc}
     * @return ResCountryStateQuery the active query used by this AR class.
     */
    public static function find()
    {
        return new ResCountryStateQuery(get_called_class());
    }
}
