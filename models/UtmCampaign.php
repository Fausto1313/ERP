<?php

namespace app\models;

use Yii;

/**
 * This is the model class for table "utm_campaign".
 *
 * @property int $id TRIAL
 * @property string $name TRIAL
 * @property int $user_id TRIAL
 * @property int $stage_id TRIAL
 * @property int|null $is_website TRIAL
 * @property int|null $color TRIAL
 * @property int|null $create_uid TRIAL
 * @property string|null $create_date TRIAL
 * @property int|null $write_uid TRIAL
 * @property string|null $write_date TRIAL
 * @property int|null $company_id TRIAL
 * @property string|null $trial562 TRIAL
 *
 * @property CrmLead[] $crmLeads
 * @property SaleOrder[] $saleOrders
 * @property ResCompany $company
 * @property ResUsers $createU
 * @property ResUsers $user
 * @property ResUsers $writeU
 */
class UtmCampaign extends \yii\db\ActiveRecord
{
    /**
     * {@inheritdoc}
     */
    public static function tableName()
    {
        return 'utm_campaign';
    }

    /**
     * {@inheritdoc}
     */
    public function rules()
    {
        return [
            [['name', 'user_id', 'stage_id'], 'required'],
            [['name'], 'string'],
            [['user_id', 'stage_id', 'is_website', 'color', 'create_uid', 'write_uid', 'company_id'], 'integer'],
            [['create_date', 'write_date'], 'safe'],
            [['trial562'], 'string', 'max' => 1],
            [['company_id'], 'exist', 'skipOnError' => true, 'targetClass' => ResCompany::className(), 'targetAttribute' => ['company_id' => 'id']],
            [['create_uid'], 'exist', 'skipOnError' => true, 'targetClass' => ResUsers::className(), 'targetAttribute' => ['create_uid' => 'id']],
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
            'name' => 'Name',
            'user_id' => 'User ID',
            'stage_id' => 'Stage ID',
            'is_website' => 'Is Website',
            'color' => 'Color',
            'create_uid' => 'Create Uid',
            'create_date' => 'Create Date',
            'write_uid' => 'Write Uid',
            'write_date' => 'Write Date',
            'company_id' => 'Company ID',
            'trial562' => 'Trial562',
        ];
    }

    /**
     * Gets query for [[CrmLeads]].
     *
     * @return \yii\db\ActiveQuery|CrmLeadQuery
     */
    public function getCrmLeads()
    {
        return $this->hasMany(CrmLead::className(), ['campaign_id' => 'id']);
    }

    /**
     * Gets query for [[SaleOrders]].
     *
     * @return \yii\db\ActiveQuery|SaleOrderQuery
     */
    public function getSaleOrders()
    {
        return $this->hasMany(SaleOrder::className(), ['campaign_id' => 'id']);
    }

    /**
     * Gets query for [[Company]].
     *
     * @return \yii\db\ActiveQuery|ResCompanyQuery
     */
    public function getCompany()
    {
        return $this->hasOne(ResCompany::className(), ['id' => 'company_id']);
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
     * @return UtmCampaignQuery the active query used by this AR class.
     */
    public static function find()
    {
        return new UtmCampaignQuery(get_called_class());
    }
}
