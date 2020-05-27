<?php

namespace app\models;

use Yii;

/**
 * This is the model class for table "res_country".
 *
 * @property int $id TRIAL
 * @property string $name TRIAL
 * @property string|null $code TRIAL
 * @property string|null $address_format TRIAL
 * @property int|null $address_view_id TRIAL
 * @property int|null $currency_id TRIAL
 * @property int|null $phone_code TRIAL
 * @property string|null $name_position TRIAL
 * @property string|null $vat_label TRIAL
 * @property int|null $create_uid TRIAL
 * @property string|null $create_date TRIAL
 * @property int|null $write_uid TRIAL
 * @property string|null $write_date TRIAL
 * @property string|null $trial434 TRIAL
 *
 * @property CrmLead[] $crmLeads
 * @property ResUsers $createU
 * @property ResUsers $writeU
 * @property ResCountryState[] $resCountryStates
 * @property ResPartner[] $resPartners
 * @property WebsiteVisitor[] $websiteVisitors
 */
class ResCountry extends \yii\db\ActiveRecord
{
    /**
     * {@inheritdoc}
     */
    public static function tableName()
    {
        return 'res_country';
    }

    /**
     * {@inheritdoc}
     */
    public function rules()
    {
        return [
            [['name'], 'required'],
            [['name', 'address_format', 'name_position', 'vat_label'], 'string'],
            [['address_view_id', 'currency_id', 'phone_code', 'create_uid', 'write_uid'], 'integer'],
            [['create_date', 'write_date'], 'safe'],
            [['code'], 'string', 'max' => 2],
            [['trial434'], 'string', 'max' => 1],
            [['code'], 'unique'],
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
            'address_format' => 'Address Format',
            'address_view_id' => 'Address View ID',
            'currency_id' => 'Currency ID',
            'phone_code' => 'Phone Code',
            'name_position' => 'Name Position',
            'vat_label' => 'Vat Label',
            'create_uid' => 'Create Uid',
            'create_date' => 'Create Date',
            'write_uid' => 'Write Uid',
            'write_date' => 'Write Date',
            'trial434' => 'Trial434',
        ];
    }

    /**
     * Gets query for [[CrmLeads]].
     *
     * @return \yii\db\ActiveQuery|CrmLeadQuery
     */
    public function getCrmLeads()
    {
        return $this->hasMany(CrmLead::className(), ['country_id' => 'id']);
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
     * Gets query for [[ResCountryStates]].
     *
     * @return \yii\db\ActiveQuery|ResCountryStateQuery
     */
    public function getResCountryStates()
    {
        return $this->hasMany(ResCountryState::className(), ['country_id' => 'id']);
    }

    /**
     * Gets query for [[ResPartners]].
     *
     * @return \yii\db\ActiveQuery|ResPartnerQuery
     */
    public function getResPartners()
    {
        return $this->hasMany(ResPartner::className(), ['country_id' => 'id']);
    }

    /**
     * Gets query for [[WebsiteVisitors]].
     *
     * @return \yii\db\ActiveQuery|WebsiteVisitorQuery
     */
    public function getWebsiteVisitors()
    {
        return $this->hasMany(WebsiteVisitor::className(), ['country_id' => 'id']);
    }

    /**
     * {@inheritdoc}
     * @return ResCountryQuery the active query used by this AR class.
     */
    public static function find()
    {
        return new ResCountryQuery(get_called_class());
    }
}
