<?php

namespace app\models;

use Yii;

/**
 * This is the model class for table "website_visitor".
 *
 * @property int $id TRIAL
 * @property string|null $name TRIAL
 * @property string $access_token TRIAL
 * @property int|null $active TRIAL
 * @property int|null $website_id TRIAL
 * @property int|null $partner_id TRIAL
 * @property int|null $country_id TRIAL
 * @property int|null $lang_id TRIAL
 * @property string|null $timezone TRIAL
 * @property int|null $visit_count TRIAL
 * @property string|null $create_date TRIAL
 * @property string|null $last_connection_datetime TRIAL
 * @property int|null $create_uid TRIAL
 * @property int|null $write_uid TRIAL
 * @property string|null $write_date TRIAL
 * @property int|null $livechat_operator_id TRIAL
 * @property string|null $trial588 TRIAL
 *
 * @property ResCountry $country
 * @property ResUsers $createU
 * @property ResLang $lang
 * @property ResPartner $livechatOperator
 * @property ResPartner $partner
 * @property ResUsers $writeU
 */
class WebsiteVisitor extends \yii\db\ActiveRecord
{
    /**
     * {@inheritdoc}
     */
    public static function tableName()
    {
        return 'website_visitor';
    }

    /**
     * {@inheritdoc}
     */
    public function rules()
    {
        return [
            [['name', 'access_token', 'timezone'], 'string'],
            [['access_token'], 'required'],
            [['active', 'website_id', 'partner_id', 'country_id', 'lang_id', 'visit_count', 'create_uid', 'write_uid', 'livechat_operator_id'], 'integer'],
            [['create_date', 'last_connection_datetime', 'write_date'], 'safe'],
            [['trial588'], 'string', 'max' => 1],
            [['partner_id'], 'unique'],
            [['country_id'], 'exist', 'skipOnError' => true, 'targetClass' => ResCountry::className(), 'targetAttribute' => ['country_id' => 'id']],
            [['create_uid'], 'exist', 'skipOnError' => true, 'targetClass' => ResUsers::className(), 'targetAttribute' => ['create_uid' => 'id']],
            [['lang_id'], 'exist', 'skipOnError' => true, 'targetClass' => ResLang::className(), 'targetAttribute' => ['lang_id' => 'id']],
            [['livechat_operator_id'], 'exist', 'skipOnError' => true, 'targetClass' => ResPartner::className(), 'targetAttribute' => ['livechat_operator_id' => 'id']],
            [['partner_id'], 'exist', 'skipOnError' => true, 'targetClass' => ResPartner::className(), 'targetAttribute' => ['partner_id' => 'id']],
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
            'access_token' => 'Access Token',
            'active' => 'Active',
            'website_id' => 'Website ID',
            'partner_id' => 'Partner ID',
            'country_id' => 'Country ID',
            'lang_id' => 'Lang ID',
            'timezone' => 'Timezone',
            'visit_count' => 'Visit Count',
            'create_date' => 'Create Date',
            'last_connection_datetime' => 'Last Connection Datetime',
            'create_uid' => 'Create Uid',
            'write_uid' => 'Write Uid',
            'write_date' => 'Write Date',
            'livechat_operator_id' => 'Livechat Operator ID',
            'trial588' => 'Trial588',
        ];
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
     * Gets query for [[Lang]].
     *
     * @return \yii\db\ActiveQuery|ResLangQuery
     */
    public function getLang()
    {
        return $this->hasOne(ResLang::className(), ['id' => 'lang_id']);
    }

    /**
     * Gets query for [[LivechatOperator]].
     *
     * @return \yii\db\ActiveQuery|ResPartnerQuery
     */
    public function getLivechatOperator()
    {
        return $this->hasOne(ResPartner::className(), ['id' => 'livechat_operator_id']);
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
     * @return WebsiteVisitorQuery the active query used by this AR class.
     */
    public static function find()
    {
        return new WebsiteVisitorQuery(get_called_class());
    }
}
